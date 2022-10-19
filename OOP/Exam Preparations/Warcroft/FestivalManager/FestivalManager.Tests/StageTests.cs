// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 


using FestivalManager.Entities;

namespace FestivalManager.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void Constructor_ShouldInitializeCollections()
	    {
			Stage stage = new Stage();

			Assert.NotNull(stage.Performers);
		}

        [Test]
        public void ValidatePerformer()
        {
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(
                () => stage.AddPerformer(null));

            Performer performer = new Performer("Zagzo", "Bavniq", 16);

            Assert.Throws<ArgumentException>(
                () => stage.AddPerformer(performer));

            performer = new Performer("Zagzo", "Bavniq", 20);

            stage.AddPerformer(performer);

            Assert.AreEqual(1, stage.Performers.Count);
            Assert.True(stage.Performers.Any(x => x == performer));
        }

        [Test]
        public void Validate_AddSong()
        {
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(
                () => stage.AddSong(null));

            Song song = new Song("Glizzock", new TimeSpan(0, 0, 50));

            Assert.Throws<ArgumentException>(
                () => stage.AddSong(song));

            song = new Song("Glizzock", new TimeSpan(0, 2, 50));
            stage.AddSong(song);
        }

        [Test]
        public void Validate_AddSongToPerformer()
        {
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(
                () => stage.AddSongToPerformer(null, "greshka"));
            Assert.Throws<ArgumentNullException>(
                () => stage.AddSongToPerformer("greshka", null));

            Assert.Throws<ArgumentException>(
                () => stage.AddSongToPerformer("name", "greshka"));

            Performer performer = new Performer("Zagzo", "Bavniq", 20);
            stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(
                () => stage.AddSongToPerformer("name", performer.FullName));

            Song song = new Song("Glizzock", new TimeSpan(0, 2, 50));
            stage.AddSong(song);

            string result = stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.True(performer.SongList.Contains(song));
            Assert.AreEqual($"{song} will be performed by {performer}", result);
        }

        [Test]
        public void Validate_Play()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Zagzo", "Bavniq", 20);
            Performer performer2 = new Performer("Gosho", "Burziq", 22);
            Performer performer3 = new Performer("Boncho", "Mazniq", 32);

            Song song1 = new Song("Glizzock", new TimeSpan(0, 2, 50));
            Song song2 = new Song("Zimi", new TimeSpan(0, 2, 50));
            Song song3 = new Song("Taq stabilnata", new TimeSpan(0, 3, 50));
            Song song4 = new Song("pesen", new TimeSpan(0, 2, 50));
            Song song5 = new Song("4akal", new TimeSpan(0, 4, 50));

            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddPerformer(performer3);
            
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSong(song3);
            stage.AddSong(song4);
            stage.AddSong(song5);

            stage.AddSongToPerformer(song1.Name, performer1.FullName);
            stage.AddSongToPerformer(song2.Name, performer1.FullName);
            stage.AddSongToPerformer(song3.Name, performer1.FullName);

            stage.AddSongToPerformer(song4.Name, performer3.FullName);
            stage.AddSongToPerformer(song5.Name, performer3.FullName);

            Assert.AreEqual(3, stage.Performers.Count);

            string result = stage.Play();

            Assert.AreEqual($"{stage.Performers.Count} performers played {5} songs", result);
        }
	}
}