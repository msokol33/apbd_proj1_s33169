using EquipmentRental.EquipmentData;
using EquipmentRental.Interfaces;
using EquipmentRental.RentalServices;
using EquipmentRental.UserData;

var equipmentService = new EquipmentService();
var userService      = new UserService();
var rentalService    = new RentalService(equipmentService, userService);

new App(equipmentService, userService, rentalService).Run();

internal class App
{
    private readonly IEquipmentService _equipmentService;
    private readonly IUserService _userService;
    private readonly IRentalService _rentalService;

    public App(IEquipmentService equipmentService, IUserService userService, IRentalService rentalService)
    {
        _equipmentService = equipmentService;
        _userService = userService;
        _rentalService = rentalService;
    }

    public void Run()
    {
        var today      = DateTime.Today;
        var warrantyTo = today.AddYears(2);

        Console.WriteLine("=== 1. Dodawanie sprzętu ===");
        _equipmentService.AddNewEquipment(EquipmentType.Camera, "Canon", "EOS R5", today, warrantyTo, 35, 45);
        _equipmentService.AddNewEquipment(EquipmentType.Camera, "Sony", "A7 IV", today, warrantyTo, 35, 33);
        _equipmentService.AddNewEquipment(EquipmentType.Laptop, "Dell", "XPS 15", today, warrantyTo, 12, 15, "Windows 11");
        _equipmentService.AddNewEquipment(EquipmentType.Laptop, "Apple", "MacBook Pro", today, warrantyTo, 18, 14, "macOS");
        _equipmentService.AddNewEquipment(EquipmentType.Chair, "Herman Miller", "Aeron", today, warrantyTo, "Mesh", "Wysokość, Podłokietniki");
        _equipmentService.AddNewEquipment(EquipmentType.Projector, "Epson", "EB-L735U", today, warrantyTo, 3, 1080);
        _equipmentService.AddNewEquipment(EquipmentType.Projector, "BenQ", "MH535FHD", today, warrantyTo, 2, 1080);
        _equipmentService.AddNewEquipment(EquipmentType.Camera, "Nikon", "Z6 II", today, warrantyTo, 35, 24);
        _equipmentService.AddNewEquipment(EquipmentType.Laptop, "Lenovo", "ThinkPad X1", today, warrantyTo, 14, 14, "Windows 11 Pro");
        _equipmentService.AddNewEquipment(EquipmentType.Chair, "Steelcase", "Gesture", today, warrantyTo, "Tkanina", "Wysokość, Zagłówek, Podłokietniki");
        _equipmentService.AddNewEquipment(EquipmentType.Projector, "Optoma", "UHD35", today, warrantyTo, 1, 2160);
        _equipmentService.AddNewEquipment(EquipmentType.Camera, "Fujifilm", "X-T5", today, warrantyTo, 40, 40);
        _equipmentService.DisplayEquipment();
        
        var lenovoThinkPad = _equipmentService.GetEquipmentByBrandAndModel("Lenovo", "ThinkPad X1");
        _equipmentService.MarkAsNotInService(lenovoThinkPad.Id);

        _equipmentService.DisplayEquipment();

        var canonCamera = _equipmentService.GetEquipmentByBrandAndModel("Canon", "EOS R5");
        var sonyCamera = _equipmentService.GetEquipmentByBrandAndModel("Sony", "A7 IV");
        var dellLaptop = _equipmentService.GetEquipmentByBrandAndModel("Dell", "XPS 15");
        var macbook = _equipmentService.GetEquipmentByBrandAndModel("Apple", "MacBook Pro");
        var epsonProjector = _equipmentService.GetEquipmentByBrandAndModel("Epson", "EB-L735U");
        var benqProjector = _equipmentService.GetEquipmentByBrandAndModel("BenQ", "MH535FHD");
        var nikonCamera = _equipmentService.GetEquipmentByBrandAndModel("Nikon", "Z6 II");
        var steelcaseChair = _equipmentService.GetEquipmentByBrandAndModel("Steelcase", "Gesture");
        var optomaProjector = _equipmentService.GetEquipmentByBrandAndModel("Optoma", "UHD35");
        var fujifilmCamera = _equipmentService.GetEquipmentByBrandAndModel("Fujifilm", "X-T5");

        Console.WriteLine("\n=== 2. Dodawanie użytkowników ===");
        _userService.Create(UserType.Student, "Jan", "Kowalski");
        _userService.Create(UserType.Student, "Anna", "Nowak");
        _userService.Create(UserType.Employee, "Piotr", "Wiśniewski");
        _userService.Create(UserType.Employee, "Maria", "Zając");
        _userService.Create(UserType.Employee, "Tomasz", "Mazur");

        var jan  = _userService.GetUserByNameAndSurname("Jan", "Kowalski");
        var anna   = _userService.GetUserByNameAndSurname("Anna", "Nowak");
        var piotr  = _userService.GetUserByNameAndSurname("Piotr", "Wiśniewski");
        var maria  = _userService.GetUserByNameAndSurname("Maria", "Zając");
        var tomasz = _userService.GetUserByNameAndSurname("Tomasz", "Mazur");

        Console.WriteLine("\n=== 3. Poprawne wypożyczenia ===");
        _rentalService.Rent(piotr.Id, canonCamera.Id, 7);
        _rentalService.Rent(piotr.Id, dellLaptop.Id, 5);
        _rentalService.Rent(jan.Id, sonyCamera.Id, 3);
        _rentalService.Rent(maria.Id, benqProjector.Id, 4);
        _rentalService.Rent(anna.Id, steelcaseChair.Id, 6);
        _rentalService.Rent(tomasz.Id, nikonCamera.Id, 2);
        _rentalService.Rent(maria.Id, optomaProjector.Id, 2);
        _rentalService.Rent(piotr.Id, fujifilmCamera.Id, 1);

        _rentalService.DisplayActiveRentalForUser(piotr.Id);
        _rentalService.DisplayActiveRentalForUser(jan.Id);
        _rentalService.DisplayActiveRentalForUser(maria.Id);
        _rentalService.DisplayActiveRentalForUser(anna.Id);
        _rentalService.DisplayActiveRentalForUser(tomasz.Id);

        Console.WriteLine("\n=== 4. Niepoprawne operacje ===");
        Console.WriteLine("Próba wypożyczenia zajętego Canon EOS R5 przez Annę:");
        try
        {
            _rentalService.Rent(anna.Id, canonCamera.Id, 2);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        _rentalService.Rent(jan.Id, macbook.Id, 2);
        Console.WriteLine("Próba przekroczenia limitu studenta Jana:");
        try
        {
            _rentalService.Rent(jan.Id, epsonProjector.Id, 1);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        Console.WriteLine("Próba wypożyczenia sprzętu NotInService przez Marię:");
        try
        {
            _rentalService.Rent(maria.Id, lenovoThinkPad.Id, 3);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        Console.WriteLine("Próba wypożyczenia zajętego projektora BenQ przez Tomasza:");
        try
        {
            _rentalService.Rent(tomasz.Id, benqProjector.Id, 2);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        Console.WriteLine("\n=== 5. Zwrot w terminie ===");
        var canonRental = _rentalService.GetRentalByEquipmentId(canonCamera.Id);
        _rentalService.Return(canonRental);

        var chairRental = _rentalService.GetRentalByEquipmentId(steelcaseChair.Id);
        _rentalService.Return(chairRental);

        Console.WriteLine("\n=== 6. Zwrot z opóźnieniem ===");
        var dellRental = _rentalService.GetRentalByEquipmentId(dellLaptop.Id);
        dellRental.RentTo = DateTime.UtcNow.AddDays(-5).AddHours(-6);
        _rentalService.Return(dellRental);

        var benqRental = _rentalService.GetRentalByEquipmentId(benqProjector.Id);
        benqRental.RentTo = DateTime.UtcNow.AddDays(-2).AddHours(-3);
        _rentalService.Return(benqRental);
        
        //Przeterminowane aktywne wypożyczenie
        var optomaRental = _rentalService.GetRentalByEquipmentId(optomaProjector.Id);
        optomaRental.RentTo = DateTime.UtcNow.AddDays(-2);
        _rentalService.DisplayExpiredRentals();
        
        
        //koncowe wyswietlenie informacji wspomnianych w liscie wymagan
        _equipmentService.DisplayAvailableEquipment();
        _rentalService.DisplayRentalReport();
    }
}

