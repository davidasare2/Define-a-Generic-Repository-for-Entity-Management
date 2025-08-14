public class HealthSystemApp
{
    private readonly Repository<Patient> _patientRepo = new();
    private readonly Repository<Prescription> _prescriptionRepo = new();
    private readonly Dictionary<int, List<Prescription>> _prescriptionMap = new();

    public void SeedData()
    {
        // Add sample patients
        _patientRepo.Add(new Patient(1, "John Doe", 45, "Male"));
        _patientRepo.Add(new Patient(2, "Jane Smith", 32, "Female"));

        // Add sample prescriptions
        _prescriptionRepo.Add(new Prescription(1, 1, "Ibuprofen", DateTime.Now.AddDays(-10)));
        _prescriptionRepo.Add(new Prescription(2, 1, "Amoxicillin", DateTime.Now.AddDays(-5)));
        _prescriptionRepo.Add(new Prescription(3, 2, "Lisinopril", DateTime.Now.AddDays(-15)));
    }

    public void BuildPrescriptionMap()
    {
        foreach (var prescription in _prescriptionRepo.GetAll())
        {
            if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                _prescriptionMap[prescription.PatientId] = new List<Prescription>();

            _prescriptionMap[prescription.PatientId].Add(prescription);
        }
    }

    public void PrintAllPatients()
    {
        Console.WriteLine("=== PATIENTS ===");
        foreach (var patient in _patientRepo.GetAll())
            Console.WriteLine(patient);
        Console.WriteLine();
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
        var patient = _patientRepo.GetById(p => p.Id == patientId);
        if (patient == null)
        {
            Console.WriteLine($"Patient ID {patientId} not found!");
            return;
        }

        Console.WriteLine($"=== PRESCRIPTIONS FOR {patient.Name.ToUpper()} ===");
        if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
            foreach (var p in prescriptions)
                Console.WriteLine(p);
        else
            Console.WriteLine("No prescriptions found");
        Console.WriteLine();
    }
}