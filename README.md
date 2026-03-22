EquipmentRental - projekt APBD
Prosta aplikacja konsolowa w .NET 9 symulująca wypożyczalnię sprzętu. Pozwala dodawać sprzęt różnych typów, rejestrować użytkowników (student, pracownik), wypożyczać i zwracać sprzęt z naliczaniem opłaty za opóźnienie.

1. Podział na warstwy i foldery

Kod podzieliłem na cztery osobne obszary: dane sprzętowe (EquipmentData), dane użytkowników (UserData), dane wypożyczeń (RentalData) i serwisy (RentalServices). Każdy folder trzyma klasy należące do jednego tematu. Takie rozbicie sprawia, że szukając czegoś wiadomo od razu gdzie patrzeć, a zmieniając np. model sprzętu nie dotykam logiki wypożyczeń.
Klasy modeli (EquipmentBase, User, Rental i ich pochodne) nie zawierają żadnej logiki biznesowej - są czyste nośniki danych. Cała logika siedzi w serwisach. To celowa decyzja: model nie powinien wiedzieć jak się liczy opłata za spóźnienie, a serwis nie powinien trzymać stanu w polach.

2. Kohezja

Każdy serwis ma jedno zadanie. EquipmentService zajmuje się wyłącznie stanem listy sprzętu - dodawaniem, wyszukiwaniem i zmianą statusu. UserService zarządza użytkownikami i ich licznikami wypożyczeń. RentalService koordynuje wypożyczenie i zwrot, delegując weryfikację dostępności sprzętu i limitu użytkownika do pozostałych serwisów zamiast robić to samemu.

3. Coupling

RentalService w konstruktorze przyjmuje IEquipmentService i IUserService, a nie konkretne klasy. Gdybym jutro chciał podmienić UserService na wersję z bazą danych, RentalService tego nie poczuje. Analogicznie klasa App w Program.cs przyjmuje przez konstruktor trzy interfejsy - sam main tylko tworzy obiekty i przekazuje je dalej. To odwrócenie zależności na poziomie entry pointu projektu.

4. Odpowiedzialności klas

RentalLimits to oddzielna klasa z dwiema stałymi. Dzięki temu zarówno Student jak i Employee odwołują się do tego samego źródła prawdy i zmiana limitu to jedna linijka w jednym miejscu.
Student i Employee dziedziczą po User, ale jedyne co nadpisują to przekazanie właściwego limitu do konstruktora bazowego. Nie ma tu żadnej dodatkowej logiki, bo każda różnica między typami użytkownika sprowadza się właśnie do limitu.
Printy na konsoli są w serwisach, a nie w App. Serwis wie kiedy coś się dzieje w jego domenie, więc logowanie tego co robi ma sens blisko samej akcji. App nie musi wiedzieć jak przebiega wypożyczenie od środka żeby coś wypisać.

