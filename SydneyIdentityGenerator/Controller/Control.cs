using Controller.Models;
using System;

namespace Controller
{
    public class Control
    {

        // What will this class contain :
        // 1. State pattern -> different depending on the state 
        // 2. What happens if user selects different options?

        public string GeneratePersonsAndWriteToCsv(int amountToGenerate, string parameters, string fileName)
        {
            try
            {
                IPerson[] records = GeneratePersons(amountToGenerate, parameters);

                CsvFileWriter.Write(fileName, parameters, records);
            }
            catch (Exception ex)
            {
                return "An error has occured : " + ex.Message;
            }
            return "success";
        }


        private IPerson[] GeneratePersons(int amountToGenerate, string parameters)
        {
            //defining
            IPerson[] output = new IPerson[amountToGenerate];
            for(var i = 0; i < amountToGenerate; i++)
            {
                output[i] = new Male();
            }

            return output;
        }

    }
}
