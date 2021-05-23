using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class Control
    {
        private readonly EmailGenerator emailGenerator = new();
        private readonly GenderGenerator genderGenerator = new();
        private readonly NameGenerator nameGenerator = new();
        private readonly AddressGenerator addressGenerator = new();
        private readonly DateOfBirthGenerator dateOfBirthGenerator = new();
        private readonly PhoneNumberGenerator phoneNumberGenerator = new();

        public string GeneratePersonsAndWriteToCsv(int amountToGenerate, string parameters, string fileName)
        {
            try
            {
                Person[] records = GeneratePersons(amountToGenerate, parameters);

                CsvFileWriter.Write(fileName, parameters, records);
            }
            catch (Exception ex)
            {
                return "An error has occured : " + ex.Message;
            }
            return "success";
        }

        private Person[] GeneratePersons(int amountToGenerate, string parameters)
        {
            //defining
            List<string> parameterList = parameters.Split(',').ToList();
            bool firstNameRequired = parameterList.Contains("first_name");
            bool lastNameRequired = parameterList.Contains("last_name");
            bool addressRequired = parameterList.Contains("address");
            bool phoneNumberRequired = parameterList.Contains("phone_number");
            bool dateOfBirthRequired = parameterList.Contains("dob");
            bool genderRequired = parameterList.Contains("gender");
            bool emailRequired = parameterList.Contains("email");

            Person[] output = new Person[amountToGenerate];

            for (int i = 0; i < amountToGenerate; i++)
            {
                Person toAdd = new();

                //gender, firstname and lastname are generated no matter what,
                //because they are needed for email

                string gender = genderGenerator.GenerateGender();
                string firstName = nameGenerator.GenerateFirstName(gender);
                string lastName = nameGenerator.GenerateLastName();

                if (firstNameRequired)
                {
                    toAdd.FirstName = firstName + ",";
                }
                if (lastNameRequired)
                {
                    toAdd.LastName = lastName + ",";
                }
                if (addressRequired)
                {
                    toAdd.Address = "\"" + addressGenerator.GenerateRandomSydneyAddress() + "\"" + ",";
                }
                if (phoneNumberRequired)
                {
                    toAdd.PhoneNumber = phoneNumberGenerator.GeneratePhoneNumber() + ",";
                }
                if (dateOfBirthRequired)
                {
                    toAdd.DateOfBirth = dateOfBirthGenerator.GenerateRandomDate() + ",";
                }
                if (genderRequired)
                {
                    toAdd.Gender = gender + ",";
                }
                if (emailRequired)
                {
                    toAdd.Email = emailGenerator.GenerateEmail(firstName, lastName) + ",";
                }

                output[i] = toAdd;
            }

            return output;
        }


    }
}
