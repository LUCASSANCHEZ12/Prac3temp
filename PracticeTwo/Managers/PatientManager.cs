using UPB.PracticeTwo.Models;
using System;

namespace UPB.PracticeTwo.Managers;

public class PatientManager
{
    private List<Patients> _patients;
    
    public PatientManager()
    {
        _patients = new List<Patients>();
    }

    public List<Patients> GetAll()
    {
        return _patients;
    }

    public Patients GetByCI(int ci)
    {
        if (ci < 0)
        {
            throw new Exception("CI invalido");
        }

        Patients patientfound = _patients.Find(patient => patient.CI == ci);
        if(patientfound == null)
        {
            throw new Exception("Error, Patient not found");
        }
        return patientfound;
    }

    public Patients Update(int ci, string name, string lastname)
    {
        if (ci < 0)
        {
            throw new Exception("CI invalido");
        }

        Patients patientfound;
        patientfound = _patients.Find(patient => patient.CI == ci);

        if (patientfound == null)
        {
            throw new Exception("Error, Patient not found");
        }

        patientfound.Name = name;
        patientfound.LastName = lastname;

        return patientfound;
    }
    public Patients Create(string name, string lastname, int age, int ci)
    {
        if(_patients.Find(patient => patient.CI == ci) != null)
        {
            throw new Exception("Error, CI existente");
        }

        if(ci < 0)
        {
            throw new Exception("Error, CI no valido");
        }

        Random rnd = new Random();
        string[] BloodGroup = new string[] {"A+","A-","B+","B-","AB+","AB-","O-","O+"};
        Patients createdPatient = new Patients()
        {
            Name = name,
            LastName = lastname,
            Age = age,
            CI = ci,
            BloodGroup = BloodGroup[rnd.Next(0,7)]
        };
        _patients.Add(createdPatient);
        return createdPatient;
    }

    public Patients Delete(int ci)
    {
        int patientToDeleteIndex = _patients.FindIndex(patient => patient.CI == ci);
        Patients patientToDelete = _patients[patientToDeleteIndex];
        _patients.RemoveAt(patientToDeleteIndex);
        return patientToDelete;
    }
}