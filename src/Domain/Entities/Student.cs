using System;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities;

public class Student : SoftDeletableEntity<int>
{
    public int? GenerationId { get; set; }
    public string? Nik { get; set; }
    public string? Nis { get; set; }
    public string? Nisn { get; set; }
    public string Name { get; set; } = null!;
    public string? Gender { get; set; }
    public string? BirthPlace { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Nickname { get; set; }
    public string? PreviousSchool { get; set; }
    public string? ProfilePicture { get; set; }
    public string? FamilyCardNo { get; set; }
    public string? FatherIdNo { get; set; }
    public string? FatherName { get; set; }
    public string? FatherPhoneNo { get; set; }
    public string? FatherEmail { get; set; }
    public string? FatherOccupation { get; set; }
    public int? FatherSalary { get; set; }
    public string? MotherIdNo { get; set; }
    public string? MotherName { get; set; }
    public string? MotherPhoneNo { get; set; }
    public string? MotherEmail { get; set; }
    public string? MotherOccupation { get; set; }
    public string? CommunicationPhoneNo { get; set; }
    public string? CommunicationEmail { get; set; }
    public string? Address { get; set; }
    public string? Rt { get; set; }
    public string? Rw { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public decimal? Distance { get; set; }
    public byte? TravelTime { get; set; }
    public string? LongLat { get; set; }

    public Generation? Generation { get; set; }
    public ICollection<SchoolYearStudent> SchoolYearStudents { get; set; } = new HashSet<SchoolYearStudent>();
    public ICollection<Saving> Savings { get; set; } = new HashSet<Saving>();
}
