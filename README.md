# Entiteti

## Student
* ID(Primarni Kljuc)
* Ime
* Prezime
* Adresa
* Grad
* Drzava
* DatumRodjenja
* Pol
* PohadjaniKursevi

##  Kurs
* ID(Primarni Kljuc)
* Sifra
* Ime
* Opis
* PohadjaniKursevi

## Studentkurs
* ID(Primarni Kljuc)
* Ocena
* Student(Strani Kljuc)
* Kurs(Strani Kljuc)

## Veze

**Student-1-N-StudentKurs-M-1-Kurs**

Jedan Student moze da pohadja vise Kurseva preko StudentKurs entiteta.

Jedan Kurs mogu da pohadjaju vise Studenta preko StudentKurs entiteta.

### Objasnjenje

Uveo sam treci entitet, jer direktna veza izmedju Student i Kurs entiteta dovodi do dupliciranje i nepreciznosti podataka. StudentKurs entitet spaja konkretnog Studentam konkretan Kurs i Ocenu za taj kurs.

# Pattern

Iskoristio sam Repository pattern, zbog bolje organizacije koda, apstrahovanja pristupa podacima i lakseg testiranja.

# Kontroleri

* StudentController
* KursController
* StudentKursController

Svi imaju implementirane CRUD operacije.
# Frontend

![Image 1](/slike/1.png)
![Image 2](/slike/2.png)
![Image 3](/slike/3.png)