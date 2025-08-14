class Program
{
    static void Main()
    {
        var app = new HealthSystemApp();

        // Initialize data
        app.SeedData();
        app.BuildPrescriptionMap();

        // Display data
        app.PrintAllPatients();

        // Get user input
        Console.Write("Enter Patient ID to view prescriptions: ");
        if (int.TryParse(Console.ReadLine(), out int patientId))
            app.PrintPrescriptionsForPatient(patientId);
        else
            Console.WriteLine("Invalid input!");
    }
}