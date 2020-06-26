Denumire aplicatie -> Free Lance Platform
Tehnologii utilizate -> Backend: ASP.Net core 
			FrontEnd: React.js
			Database: SQL Server

Short description:
Proiectul consta intr-o aplicatie web in care poti adauga orice tip de job avand un cont de Employeer
in orice domeniu, iar ca user cu rol de employee ai acces la orice job postat in main page, acolo gasesti
toate detaliile despre joburi puse in cate un modal specific, tot aici poti aplica pentru jobul ales.
Odata ce userul a aplicat pentru job acesta va aparea in main page-ul employeer-ului care a creat jobul la sectiunea 
jobului respectiv cu un avatar specific. User-ul cu calitate de emplyee are optiunea de a-si completa profilul cu detalii
lui personale inclusiv un CV descarcabil.
Employeer-ul poate accesa pe baza de index pagina acelui candidat pt a vedea mai multe informatii si inclusiv sa
descarce cv-ul acestuia.
Tot in main page de employeer ai optiunea de a creea, sterge, updata fiecare field dintr-un job specific.

Ghid Instalare:
Pt accesa pagina de login a aplicatiei foloseste ruta localhost:3000/Login am avut anumite probleme cu routing-ul 
pe partea de public route si private route.
Pt a crea un user de test poti accesa ruta localhost:3000/Register si sa creezi doua conturi specifice de employee/employeer
Dupa ce ai descarcat solutia de pe git, poti deschide proiectul cu vs code si vs community
Pentru partea de react.js inainte de a porni aplicatia este nevoie sa rulezi comanda npm install in cazul 
in care ai node.js instalat pe pc.
Pentru backend trebuie facut restore nuget packages si cred ca totul e ok
Iar pt db voi include un backup la db-ul meu acual pe care il poti pune in sql server manager

Detalii implementare specificatii din curs/detalii implementare:
- utilizare git
- descriere UML prezentata printre primele cursuri
- implementare logging pentru proiectul de asp.net core utilizate pe cel mai inalt layer aplicatiei
  respectiv pe fiecare controller
- unit testing realizat prin crearea unui nou proiect de testare in interiorul solutiei, testing realizat in special
  pe metodele de din clasele repositories care fac CRUD pe baza de date
- object relational mapping am utilizat Entity framework
- partea login este realizata cu token jwt si bearer authentification de altfel fiecare metoda din service-urile
  din UI trimit ca parametru de authorizare acest token pentru a fi un request valid
- Ca si pattern pe aplicatie am utilizat repository pattern respectiv unit of work
- in backend se regaseste de altfel si dependency injection pt injectarea interfetelor in controllere
- am utilizat ca si arhitectural pattern mvvm (model-view view model) maparea intre aceste clase se face cu un automapper
- pricipii solid, am utlizat single responsability
- exista o clasa de custom exception care preia eventualele exceptii de pe cotrollere
- utilizare majoritatea operatiilor de CRUD Rest Api in aplicatie in functie de ce exista pe UI iar metodele comunica asincron 
  cu service-urile ce fac request de pe UI
- relatiile din db le-am realizat cu entity framework majoritatea fiind one to many, many to one si many to many

Front End:
 - structura arhitecturala descrisa pe mai multe componente separate
 - componenta de service este cea care face fetch(request) catre server 
 - metodele din service-uri sunt toate async si await pt astepta raspunsul de pe server
 - in rest parte de framework react js incarca datele de pe server si le valideaza
 - pe ui exista validatori atat pe partea de login cat si pe cea de sign-up

Database: 
 - sql server
 - tabele create cu entity framework pe clasele de model de pe server
 - trebuie modificat connection string-ul care va veni pe appsetting.json cu cel de pe pc-ul tau pt a functiona query-ueile 
   catre db

