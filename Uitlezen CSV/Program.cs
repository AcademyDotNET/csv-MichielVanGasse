using System;

namespace Uitlezen_CSV
{
	class Program
	{
		static void Main(string[] args)
		{
			PokemonDatabase();
		}

		private static void PokemonDatabase()
		{
			System.Net.WebClient webC = new System.Net.WebClient();
			string csv = webC.DownloadString("https://gist.githubusercontent.com/armgilles/194bcff35001e7eb53a2a8b441e8b2c6/raw/92200bc0a673d5ce2110aaad4544ed6c4010f687/pokemon.csv");

			bool correctInput = true;
			int[] requestList;
			string input;
			string output = "";

			// get user input of wanted data
			do
			{
				correctInput = true;
				Console.WriteLine("Wich data do you want? pokenumber,name,type1,type2,total,HP,attack,defense,spAtk,spDef,speed,generation,legendary");
				input = Console.ReadLine();
				string[] inputSplit = input.Split(',');
				requestList = new int [inputSplit.Length];
				input = "";
				for (int i =0; i < inputSplit.Length; i++)
				{
					input += inputSplit[i] + " ";
					requestList[i] = GetRequestList(inputSplit[i]);
					if(requestList[i] == -1)
					{
						correctInput = false;
					}				
				}
				
			} while (!correctInput);

			string[] splitted = csv.Split('\n');
			string[] lijnsplit = new string [splitted[0].Split(',').Length];
			int [] length = new int [requestList.Length]; // store longest string of category to space evenly
			
			// get longest string in list for equal space
			for (int i = 1; i < splitted.Length - 1; i++)
			{
				lijnsplit = splitted[i].Split(',');
				for (int j = 0; j < requestList.Length; j++)
				{
					if (lijnsplit[requestList[j]].Length > length[j])
					{
						length[j] = lijnsplit[requestList[j]].Length;
					}
				}
			}
			
			// show the list evenly spaced
			for (int i = 1; i < splitted.Length - 1; i++)
			{
				lijnsplit = splitted[i].Split(',');
				for (int j = 0; j < requestList.Length; j++)
				{	
					Console.Write($"{lijnsplit[requestList[j]]}" + new string(' ', length[j] - lijnsplit[requestList[j]].Length) + "\t");
				}
				Console.WriteLine();
			}

			int from = 0;
			int to = 0;
			bool invalid = true;

			// select range to output to file and screen
			do
			{
				Console.WriteLine("Wich data do you want? from 1 to 801");
				string inputRange = Console.ReadLine();
				string[] inputRangeAr = inputRange.Split(' ');
				if (Int32.TryParse(inputRangeAr[0], out from) && Int32.TryParse(inputRangeAr[1], out to))
				{
					if (from > 0 && from < to && to <= 801)
					{
						invalid = false;
					}
				}

			} while (invalid);

			// output to file and screen selected range
			for (int i = from; i < to; i++)
			{
				lijnsplit = splitted[i].Split(',');
				for (int j = 0; j < requestList.Length; j++)
				{
					Console.Write($"{lijnsplit[requestList[j]]}" + new string(' ', length[j] - lijnsplit[requestList[j]].Length) + "\t");
					//Console.WriteLine($"{input}: {lijnsplit[requestList]}");
					output += $"{lijnsplit[requestList[j]]}" + new string(' ', length[j] - lijnsplit[requestList[j]].Length) + "\t";
				}
				Console.WriteLine();
				output += "\n";
			}

			CsvWriter.WriteTXTStreamWriter(input, output);
		}

		private static int GetRequestList(string input)
		{
			switch (input)
			{
				case "pokenumber":
					return 0;
				case "name":
					return 1;
				case "type1":
					return 2;
				case "type2":
					return 3;
				case "total":
					return 4;
				case "HP":
					return 5;
				case "attack":
					return 6;
				case "defense":
					return 7;
				case "spAtk":
					return 8;
				case "spDef":
					return 9;
				case "speed":
					return 10;
				case "generation":
					return 11;
				case "legendary":
					return 12;
				default:
					return -1;

			}
		}

	}
}
