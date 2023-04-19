namespace SoftJail.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Xml.Serialization;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using AutoMapper;
    using Newtonsoft.Json;

    using Data;
    using ImportDto;
    using Data.Models;
    using Data.Models.Enums;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            DepartmentWithCellsDto[] departmentDtos =
                JsonConvert.DeserializeObject<DepartmentWithCellsDto[]>(jsonString);

            ICollection<Department> validDepartments = new List<Department>();

            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if (!departmentDto.Cells.Any())
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if (departmentDto.Cells.Any(c => !IsValid(c)))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentDto.Name
                };

                foreach (var cellDto in departmentDto.Cells)
                {
                    Cell cell = Mapper.Map<Cell>(cellDto);
                    department.Cells.Add(cell);
                }

                validDepartments.Add(department);
                output.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            PrisonerWithMailsDto[] prisonerDtos =
                JsonConvert.DeserializeObject<PrisonerWithMailsDto[]>(jsonString);

            ICollection<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                if (prisonerDto.Mails.Any(mDto => !IsValid(mDto)))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;

                if (!string.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        output.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                };

                foreach (var mailDto in prisonerDto.Mails)
                {
                    Mail mail = Mapper.Map<Mail>(mailDto);
                    prisoner.Mails.Add(mail);
                }

                validPrisoners.Add(prisoner);
                output.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OfficerWithPrisonersDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);

            OfficerWithPrisonersDto[] officerDtos = (OfficerWithPrisonersDto[])xmlSerializer.Deserialize(reader);

            ICollection<Officer> validOfficers = new List<Officer>();

            foreach (var officerDto in officerDtos)
            {
                if (!IsValid(officerDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                bool isPositionEnumValid = Enum.TryParse(typeof(Position), officerDto.Position, out object positionObj);
                if (!isPositionEnumValid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                bool isWeaponEnumValid = Enum.TryParse(typeof(Weapon), officerDto.Weapon, out object weaponObj);
                if (!isWeaponEnumValid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                //if (!context.Departments.Any(d => d.Id == officerDto.DepartmentId))
                //{
                //    output.AppendLine("Invalid Data");
                //    continue;
                //}

                Officer officer = new Officer()
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = (Position)positionObj,
                    Weapon = (Weapon)weaponObj,
                    DepartmentId = officerDto.DepartmentId
                };

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    OfficerPrisoner op = new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prisonerDto.Id
                    };

                    officer.OfficerPrisoners.Add(op);
                }

                validOfficers.Add(officer);
                output.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}