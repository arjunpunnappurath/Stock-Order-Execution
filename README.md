# Stock-Order-Execution

This is a stock order execution program where the code consumes an input csv file and processes the transactions in it
and writes an output file.

How to run the code:

Please create a folder structure that is similar to the one that is found in the apps config of the code 
and past the input file. Also create the respective folder structure for the output file to be delivered and run the code.

Class Design

Stock

This class is a blue-print which encapsulates the properties of a stock object. This comprises of
id,company,side,quantity,remaning quantity and the status.
This also contains a funtion to update the status with respect to the value of remaining quantity.
We are alsp over-riding the the Equals function and defining the parameters for comparision.

StockParser

This class implements an interface with an abstract function read().
The class also contains the variable to hold the input file name.
The file parser function is defined in this class which contains the logic to read the inputs from the input file.

Stock Processor

This class contains the function that is responsible for the stock order execution logic. We have made use of dictionary data structures for enabling us to process the stocks.

Stock Output.

This class contains the function that simply creates an output file post the processing.

Developer : Arjun Parameswaran
