using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class DbInitializer
    {
        public static async void Initialize(SWAContext context)
        {
            context.Database.EnsureCreated();

            // Seed Kursevi table
            if (!context.Kursevi.Any())
            {
                var kursevi = new List<Kurs>
                {
                    new Kurs { Sifra = "ENG101", Ime = "English 101", Opis = "Introduction to English language" },
                    new Kurs { Sifra = "MATH101", Ime = "Mathematics 101", Opis = "Introduction to mathematics" },
                    new Kurs { Sifra = "PHY101", Ime = "Physics 101", Opis = "Introduction to physics" },
                    new Kurs { Sifra = "CHEM101", Ime = "Chemistry 101", Opis = "Introduction to chemistry" },
                    new Kurs { Sifra = "BIO101", Ime = "Biology 101", Opis = "Introduction to biology" },
                    new Kurs { Sifra = "HIST101", Ime = "History 101", Opis = "Introduction to history" },
                    new Kurs { Sifra = "GEOG101", Ime = "Geography 101", Opis = "Introduction to geography" },
                    new Kurs { Sifra = "COMP101", Ime = "Computer Science 101", Opis = "Introduction to computer science" }
                };
                context.Kursevi.AddRange(kursevi);
                context.SaveChanges();
            }

            // Seed Studenti table
            if (!context.Studenti.Any())
            {
                var studenti = new List<Student>
                {
                    new Student { Ime = "John", Prezime = "Doe", Adresa = "123 Main Street", Grad = "New York", Drzava = "USA", DatumRodjenja = DateTime.Parse("2000-01-01"), Pol = false },
                    new Student { Ime = "Jane", Prezime = "Doe", Adresa = "456 Elm Street", Grad = "Los Angeles", Drzava = "USA", DatumRodjenja = DateTime.Parse("2001-02-02"), Pol = true },
                    new Student { Ime = "Mark", Prezime = "Smith", Adresa = "789 Oak Street", Grad = "Chicago", Drzava = "USA", DatumRodjenja = DateTime.Parse("1999-03-03"), Pol = false },
                    new Student { Ime = "Mary", Prezime = "Johnson", Adresa = "101 Maple Street", Grad = "Boston", Drzava = "USA", DatumRodjenja = DateTime.Parse("2002-04-04"), Pol = true },
                    new Student { Ime = "David", Prezime = "Lee", Adresa = "345 Pine Street", Grad = "San Francisco", Drzava = "USA", DatumRodjenja = DateTime.Parse("1998-05-05"), Pol = false },
                    new Student { Ime = "Sarah", Prezime = "Williams", Adresa = "567 Cedar Street", Grad = "Seattle", Drzava = "USA", DatumRodjenja = DateTime.Parse("2003-06-06"), Pol = true },
                    new Student { Ime = "James", Prezime = "Brown", Adresa = "890 Walnut Street", Grad = "Dallas", Drzava = "USA", DatumRodjenja = DateTime.Parse("1997-07-07"), Pol = false },
                    new Student { Ime = "Linda", Prezime = "Davis", Adresa = "234 Cherry Street", Grad = "Houston", Drzava = "USA", DatumRodjenja = DateTime.Parse("2004-08-08"), Pol = true }
                };
                context.Studenti.AddRange(studenti);
                context.SaveChanges();
            }

            // Seed PohadjaniKursevi table
            // Seed StudentKursevi table
            if (!context.PohadjaniKursevi.Any())
            {
                var students = context.Studenti.ToList();
                var kursevi = context.Kursevi.ToList();

                var studentKursevi = new List<StudentKurs>
                {
                    new StudentKurs { Ocena = 8, Student = students[0], Kurs = kursevi[0] },
                    new StudentKurs { Ocena = 9, Student = students[0], Kurs = kursevi[1] },
                    new StudentKurs { Ocena = 7, Student = students[0], Kurs = kursevi[2] },
                    new StudentKurs { Ocena = 7, Student = students[1], Kurs = kursevi[0] },
                    new StudentKurs { Ocena = 8, Student = students[1], Kurs = kursevi[1] },
                    new StudentKurs { Ocena = 9, Student = students[1], Kurs = kursevi[2] },
                    new StudentKurs { Ocena = 6, Student = students[2], Kurs = kursevi[0] },
                    new StudentKurs { Ocena = 7, Student = students[2], Kurs = kursevi[1] },
                    new StudentKurs { Ocena = 8, Student = students[2], Kurs = kursevi[2] },
                    new StudentKurs { Ocena = 9, Student = students[3], Kurs = kursevi[0] },
                    new StudentKurs { Ocena = 8, Student = students[3], Kurs = kursevi[1] },
                    new StudentKurs { Ocena = 7, Student = students[3], Kurs = kursevi[2] },
                    new StudentKurs { Ocena = 9, Student = students[4], Kurs = kursevi[0] },
                    new StudentKurs { Ocena = 8, Student = students[4], Kurs = kursevi[1] },
                    new StudentKurs { Ocena = 7, Student = students[4], Kurs = kursevi[2] },
                    new StudentKurs { Ocena = 7, Student = students[5], Kurs = kursevi[0] },
                    new StudentKurs { Ocena = 8, Student = students[5], Kurs = kursevi[1] },
                    new StudentKurs { Ocena = 9, Student = students[5], Kurs = kursevi[2] },
                    new StudentKurs { Ocena = 8, Student = students[6], Kurs = kursevi[0] },
                    new StudentKurs { Ocena = 7, Student = students[6], Kurs = kursevi[1] },
                    new StudentKurs { Ocena = 6, Student = students[6], Kurs = kursevi[2] },
                    new StudentKurs { Ocena = 9, Student = students[7], Kurs = kursevi[0] },
                    new StudentKurs { Ocena = 8, Student = students[7], Kurs = kursevi[1] },
                    new StudentKurs { Ocena = 7, Student = students[7], Kurs = kursevi[2] }
                };
                context.PohadjaniKursevi.AddRange(studentKursevi);
                await context.SaveChangesAsync();

            }
        }
    }
}