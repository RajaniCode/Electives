using System;
using System.Collections.Generic;

/// <summary>
/// Article written for DotNetCurry.com
/// Summary description for Patients
/// Author:Aamir Hasan
/// www.aspxtutorial.com
/// </summary>
public class Patient
{
    public List<Patient> Lists()
    {
        List<Patient> collections = new List<Patient>{
            new Patient{ ID=1, FullName="Aamir Hasan", Address="-", PhoneNo="3335494532",   Gender='M', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=25,BloodGroup="A+",Height=5.7,Weight=79}  } },
            new Patient{ ID=2, FullName="Alicia Savoy ", Address="-", PhoneNo="76854321",   Gender='F', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=31, BloodGroup="A", Height=5.7, Weight=91}  } } ,
            new Patient{ ID=3, FullName="Jill Munzert Stagner", Address="New Jersey", PhoneNo="54528963",   Gender='F', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=39, BloodGroup="B", Height=51, Weight=91}} },
            new Patient{ ID=4, FullName="Mahwish Khan", Address="-", PhoneNo="7893356",   Gender='F', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=20, BloodGroup="O+", Height=6, Weight=50}} },
            new Patient{ ID=5, FullName="Sobia Khan", Address="-", PhoneNo="7128087",   Gender='F', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=24, BloodGroup="O-", Height=5, Weight=65}} },
            new Patient{ ID=6, FullName="Aamir Hassan", Address="-", PhoneNo="7579474",   Gender='M', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=25, BloodGroup="A+", Height=5.7, Weight=70}} },
            new Patient{ ID=7, FullName="Uma Sankari", Address="-", PhoneNo="1234567",   Gender='F', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=11, BloodGroup="A+", Height=6, Weight=14}} },
            new Patient{ ID=8, FullName="Awais Ahmed", Address="-", PhoneNo="8680953",   Gender='M', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=12, BloodGroup="B", Height=7, Weight=54}} },
            new Patient{ ID=9, FullName="Susan Baxter", Address="-", PhoneNo="5432988",   Gender='F', PatientDetails=new List<PatientDetail>{ new PatientDetail{ Age=21, BloodGroup="A", Height=5.7, Weight=51}} }
        };

        return collections;
    }

    public int ID { get; set; }
    public String FullName { get; set; }
    public string Address { get; set; }
    public string PhoneNo { get; set; }
    public char Gender { get; set; }
    public List<PatientDetail> PatientDetails { get; set; }

}

public class PatientDetail
{
    public double Height { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string BloodGroup { get; set; }
}

