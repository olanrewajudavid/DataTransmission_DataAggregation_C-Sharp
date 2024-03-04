
// Task 2: Display examples of the following Aggregate functions for users data (Username, firstname,lastname)

using Microsoft.VisualBasic;
using System.Text;
using System.Text.RegularExpressions;

namespace Assignment_2_DataTransmission_DataAggregation
{
    internal class DataAggregation
    {
        public void MinMaxStudentsID(string DataFromCSV)
        {
            string[] DataSplitted = DataFromCSV.Split("\r\n"); //split the data into a singular row record
            // Capture the students IDs in a single array of numbers
            int[] StudentIDs = Regex.Matches(DataFromCSV, "(-?[0-9]+)").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();
            int StudentIDCount = StudentIDs.Count(); // Count the number of students
            
            // Calculate the Minimum and Maximum value for Student IDs

            int FirstStudentID = StudentIDs[0]; // Initialize first ID numbers in the list of Student IDs
            int StudentIDMinimum = FirstStudentID;
            int StudentIDMaximum = FirstStudentID;
            int StudentIDAverage = FirstStudentID;       
           
            // Iterate over the Students IDs list
            for (int i = 1; i < StudentIDCount; i++)
            {
                // Calculate Minimimum value for Students ID
                if (StudentIDs[i] < StudentIDMinimum)
                    StudentIDMinimum = StudentIDs[i];

                //Calculate Maximum value for Students ID
                if (StudentIDs[i] > StudentIDMaximum)
                    StudentIDMaximum = StudentIDs[i];                
            }

            int StudentIDSum = 0; //Initialize sum of the IDs = 0
            
            // iterate over the Students IDs arrays to calculate the Student's average
            foreach (int num in StudentIDs)
            {
                StudentIDSum += num;
            }
            StudentIDAverage = StudentIDSum / StudentIDCount;

            //Print out the Aggregates Count, Minimum, Maximum and Average values to the screen
            Console.WriteLine("The total number of students = " + StudentIDCount);
            Console.WriteLine("Manimum value for Student IDs is: " + StudentIDMinimum);
            Console.WriteLine("Maximum value for Student IDs is: " + StudentIDMaximum);
            Console.WriteLine("Average of the Student IDs is : " + StudentIDAverage);
        }

        //Search Name in the CSV file starting with a user's typed letter
        public void SearchNameStartingWith(string DataFromCSV)
        {
            string[] DataSplitted = DataFromCSV.Split("\r\n"); //split the data into a singular record
            int[] StudentIDs = Regex.Matches(DataFromCSV, "(-?[0-9]+)").OfType<Match>().Select(s => int.Parse(s.Value)).ToArray();
            int StudentIDCount = StudentIDs.Count();

            //Search the file for name(s) that start with letter(s) from the user input
            Console.Write("\n\nSearch for Name starting with Letters entered by the user => ");

            //Read the starting letter entered by user
            string StartingLetter = Console.ReadLine().ToUpper();
            int Initializer = 0;
            for (int j = 0; j < StudentIDCount; j++)
            {
                string SearchName = DataSplitted[j]; // Store the record in a variable
                string[] SplitIntoParts = SearchName.Split(','); // Split the records in an array
                string firstName = SplitIntoParts[0]; // Capture first Name
                string lastName = SplitIntoParts[1]; // Capture Last Name
                string StudentID = SplitIntoParts[2]; // Capture Student's ID

                // Check if the full name starts with the input letter
                if (firstName.StartsWith(StartingLetter) || lastName.StartsWith(StartingLetter))
                {
                    Initializer++; // Count the records
                    Console.WriteLine($"{firstName} {lastName}, {StudentID}");
                }
            }
            Console.WriteLine($"Total number of students whose' names starts with letter: {StartingLetter} = {Initializer}");
        }

        //Search for a record that contains the user's letter input
        public void SearchNameContainingLetter(string DataFromCSV)
        {
            string[] DataSplitted = DataFromCSV.Split("\r\n"); //using new line as delimiter
            int[] StudentIDs = Regex.Matches(DataFromCSV, "(-?[0-9]+)").OfType<Match>().Select(r => int.Parse(r.Value)).ToArray();
            int StudentIDCount = StudentIDs.Count();

            //Read the letter entered by the user
            Console.Write("\nEnter a letter here and the system will for the name in the dierectory => ");
            string LetterInput = Console.ReadLine();
            
            int Initializer2 = 0; // initialize a variable to zero
            //Iterate the records
            for (int k = 0; k < StudentIDCount; k++)
            {
                string SearchName2 = DataSplitted[k]; // Store the record in a variable
                string[] SplitIntoParts = SearchName2.Split(','); // Split the records in an array
                string firstName2 = SplitIntoParts[0]; // Capture first Name
                string lastName2 = SplitIntoParts[1]; // Capture Last Name
                string StudentID2 = SplitIntoParts[2]; // Capture Student's ID

                // Check if the full name starts with the input letter

                if (firstName2.Contains(LetterInput) || lastName2.Contains(LetterInput))
                { 
                    Initializer2++; // Count the records
                    Console.WriteLine($"{firstName2}, {lastName2}, {StudentID2}");
                }
            }
            Console.WriteLine($"\n\n The total number of students whose names contains letter: {LetterInput} = {Initializer2}");
        }

        // Add column DateOfBirth and add values
        public void AddColumntoCSV2()
        {
            // Path to the existing CSV file
            string filePath = "C:\\Users\\olanr\\Documents\\GEORGIAN\\WINTER\\BDAT_1001\\Assignment-2_DataTransmission_DataAggregation\\Assignment-2_DataTransmission_DataAggregation\\users.csv";

            // Corresponding values for the new column
            string[] DOBValues = 
            {"01/02/1983","21/07/1985","23/05/1991", "03/07/1983", "21/02/1989", "02/11/1987",
             "20/07/1985","01/04/1982","21/02/1983", "21/03/1991", "21/03/1981", "21/06/1984",
             "13/07/1989","01/05/1988","20/04/1985", "03/04/1984", "09/05/1983", "03/07/1986",
             "04/07/1982","12/12/19841","03/05/1989", "11/06/1986", "20/07/1985", "12/09/1985",
             "09/07/1988","17/11/1987","13/07/1982", "14/01/1988", "12/09/1991", "21/10/1989",
             "20/07/1989","23/09/1989","17/09/1981" 
            };

            // Add the new column with corresponding values to the CSV file
            AddColumnToCSV(filePath, DOBValues);
            
            //Output the updated records
            string ReadDataFromCSV = File.ReadAllText(@filePath); // Retrieve data from the CSV file
            Console.WriteLine("\n Successfully added a new column DateOfBirth with values \n");
            Console.WriteLine(ReadDataFromCSV); // Print out all users from the CSV file
        }
        static void AddColumnToCSV(string FilePath, string[] newColumnValues)
        {
            // Read all lines from the existing CSV file
            string[] lines = File.ReadAllLines(FilePath);

            // Create a StringBuilder to build the modified content
            StringBuilder sb = new StringBuilder();

            // Append the new column header to the first line
            sb.AppendLine(lines[0] + ",DateOfBirth");

            // Append the new column values to each line
            for (int i = 1; i < lines.Length; i++)
            {
                sb.AppendLine(lines[i] + "," + newColumnValues[i - 1]);
            }

            // Write the modified content back to the CSV file
            File.WriteAllText(FilePath, sb.ToString());
        }

    }
}
