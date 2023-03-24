namespace MusicHub
{
    using Data;
    using System;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var producerAlbums = context
                .Albums
                .Where(p => p.ProducerId.Value == producerId)
                .ToList()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            s.Price,
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(w => w.WriterName)
                        .ToList(),
                    TotalPrice = a.Price
                })
                .OrderByDescending(p => p.TotalPrice)
                .ToList();

            foreach (var pa in producerAlbums)
            {
                sb
                    .AppendLine($"-AlbumName: {pa.AlbumName}")
                    .AppendLine($"-ReleaseDate: {pa.ReleaseDate}")
                    .AppendLine($"-ProducerName: {pa.ProducerName}")
                    .AppendLine($"-Songs:");

                int index = 1;

                foreach (var song in pa.Songs)
                {
                    sb
                        .AppendLine($"---#{index++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:f2}")
                        .AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {pa.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songsAbove = context
                .Songs
                .ToList()
                .Where(d => d.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToList(),
                    WriterName = s.Writer.Name,
                    ProducerName = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(w => w.WriterName)
                .ToList();

            int index = 1;

            foreach (var sa in songsAbove)
            {
                sb
                    .AppendLine($"-Song #{index++}")
                    .AppendLine($"---SongName: {sa.Name}")
                    .AppendLine($"---Writer: {sa.WriterName}");

                foreach (var performer in sa.Performers)
                {
                    sb.AppendLine($"---Performer: {performer}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {sa.ProducerName}")
                    .AppendLine($"---Duration: {sa.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}