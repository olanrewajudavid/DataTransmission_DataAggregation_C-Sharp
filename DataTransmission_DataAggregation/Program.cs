// Assignment - 2 Solution

// Retrieve data from the CSV - users file

// Task 1: Download file users.csv and read all users information for your class and print it to the console.
using Assignment_2_DataTransmission_DataAggregation;

Console.WriteLine("\n\n ============================= Task 1: List of users from the CSV file =============================\n\n");
// Store file absplute path in FilePath 
string FilePath = "C:\\Users\\olanr\\Documents\\GEORGIAN\\WINTER\\BDAT_1001\\Assignment-2_DataTransmission_DataAggregation\\Assignment-2_DataTransmission_DataAggregation\\users.csv";
string DataFromCSV = File.ReadAllText(@FilePath); // Retrieve data from the CSV file
Console.WriteLine(DataFromCSV); // Print out all users from the CSV file

// Task 2: Perform Data Aggregration tasks

Console.WriteLine("\n\n ============================= Task 2: Display some Agregrate values and other values ==========================\n\n");

DataAggregation AggregationTask = new DataAggregation();
AggregationTask.MinMaxStudentsID(DataFromCSV);
AggregationTask.SearchNameStartingWith(DataFromCSV);
AggregationTask.SearchNameContainingLetter(DataFromCSV);

Console.WriteLine("\n\n ========================== Task 2b: Self Study - Add a column, Date of Birth with values =============================\n\n");
AggregationTask.AddColumntoCSV2();

