using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vision_Core
{
    public static class ContainerValidator
    {

        public static ConsoleManager console;



        public static bool CheckForValidContainerCode(Parts.VideoFile videoFile)
        {
            console.ThreadLog("Validator Checking...");
            //  IF THE STRING LIST DOES NOT CONTAIN A VALID CONTAINER CODE ALREADY THEN RUN THIS SECONDARY TEST
            foreach (Parts.KeyFrameImage keyFrame in videoFile.keyFrames)
            {
                if (keyFrame.text_found.Count == 0)
                {
                    continue;
                };

                //  SEARCH ALL TEXT FOR CONTAINER CODES
                foreach (Parts.TextFound text_found in keyFrame.text_found)
                {
                    int type_code_confidence = GetConfidence_TypeCode(text_found.text);

                    if (type_code_confidence > keyFrame.type_code_confidence)
                    {
                        keyFrame.type_code_confidence = type_code_confidence;
                    };
                };


                //  APPLY CONFIDENCE TO TEXT FOUND
                foreach (Parts.TextFound text_found in keyFrame.text_found)
                {

                    if (!text_found.processed)
                    {

                        text_found.confidence = GetConfidence_ContainerCode(text_found.text);

                        if (text_found.confidence > 0)
                        {
                            text_found.confidence += keyFrame.type_code_confidence;
                        };


                        text_found.processed = true;
                    };


                };

                
                
                Parts.TextFound max_confidence_found = keyFrame.text_found[0];

                //  THEN PROCESS THROUGH ALL AND GET THE MAXIMUM CONFIDENCE
                foreach (Parts.TextFound text_found in keyFrame.text_found)
                {


                    if (text_found.processed)
                    {


                        if (text_found.confidence > max_confidence_found.confidence)
                        {
                            max_confidence_found = text_found;

                            console.ThreadLog("Found Higher Confidence = " + text_found.confidence + " > " + max_confidence_found.confidence);
                        };


                    };
                };

                //  CHECK IF THE MAXIMUM CONFIDENCE FOUND IS ABOVE THE MINIMUM CONFIDENCE SET
                if (max_confidence_found.confidence >= Vision_Core.Properties.Settings.Default.va_min_confidence)
                {
                    max_confidence_found.valid = true;
                    keyFrame.valid_text_found.Add(max_confidence_found);
                    return true;
                };
            };

            return false;
        }

        public static string[] type_codes_max = {
            "45G1",
            "45G0",
            "42G0",
            "42G1",
            "4CG0"
        };

        public static string[] type_codes_min = {
            "4561",
            "4560",
            "4260",
            "4261",
            "4C60"
        };

        public static int GetConfidence_TypeCode(string code)
        {
            int confidence = 0;

            if (code.Length == 4)
            {
                if ( type_codes_max.Contains(code) )
                {
                    confidence = 2;
                }
                else if (type_codes_min.Contains(code) )
                {
                    confidence = 1;
                };
            };

            return confidence;
        }


        public static int GetConfidence_ContainerCode(string code)
        {
            int confidence = 0;


            if (code.Length < 9 || code.Length > 11)
            {
                return confidence;
            }
            else if (code.Length == 11)
            {
                confidence += 3;
            }
            else if (code.Length == 10)
            {
                confidence += 2;
            }
            else if (code.Length == 9)
            {
                confidence += 1;
            };


            if ( CheckLeadingCharacters(code) )
            {
                confidence += 2;
            };


            if (CheckFollowingNumbers(code))
            {
                confidence += 2;
            }
            else {
                confidence -= 2;
            };

            if (confidence >= 7)
            {
                if (ValidateText(code))
                {
                    confidence += 3;
                };
            };

            return confidence;
        }







        ////////////////////////////
        //  TEXT CLEANER
        ////////////////////////////

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled).Trim('.');
        }

        public static string CleanTextFromAzure(string line)
        {

            string cleaned_text = Regex.Replace(line, @"s", "");
            string cleaned_text_2 = Regex.Replace(cleaned_text, " ", "");
            string cleaned_text_3 = Tools.TrimPunctuation(cleaned_text_2);
            cleaned_text = RemoveSpecialCharacters(cleaned_text_3);
            return cleaned_text;
        }





        /////////////////////////////////////
        //  CONTAINER CODE VALIDATOR CHECKS
        /////////////////////////////////////
        public static bool CheckLeadingCharacters(string code)
        {

            string str = code.Substring(0, 4);

            if (str.All(char.IsLetter)
                ) {
                return true;
            } else {
                return false;
            };

        }


        public static bool CheckFollowingNumbers(string code)
        {

            string str = code.Substring(4);
            console.ThreadLog("Substring >> " + str);
            if (str.All(char.IsDigit)
                )
            {
                return true;
            }
            else
            {
                return false;
            };

        }


        ////////////////////////////
        //  CONTAINER CODE VALIDATOR
        ////////////////////////////
        public static bool ValidateText(string text_detected)
        {


            console.ThreadLog("Validating: [" + text_detected + "]...");
            if (text_detected.Length != 11)
            {
                return false;
            };
            

            string lastChar = Convert.ToString(text_detected.Substring((text_detected.Length - 1), 1));

            int value;
            if (!int.TryParse(lastChar, out value))
            {
               
            }

            int last = Int32.Parse(lastChar);
            string cut_string = text_detected.Remove(text_detected.Length - 1);

            

            if (ValidateCheckDigit(cut_string, last) == "Its Good")
            {
                return true;
            }
            else
            {
                return false;
            };

        }



        const string CharCode = "0123456789A?BCDEFGHIJK?LMNOPQRSTU?VWXYZ";


        public static bool IsValid(string containerCode)
        {
            // Trim and remove spaces
            //containerCode = containerCode.Trim().Replace(" ", string.Empty);

            // Container code can not be an empty string or have a length other than 11
            if (string.IsNullOrEmpty(containerCode) || containerCode.Length != 11)
            {
                return false;
            }

            int num = 0;

            // Convert characters to uppercase
            containerCode = containerCode.ToUpper();

            for (var i = 0; i < 10; i++)
            {
                var chr = containerCode.Substring(i, 1);

                // Ensure that the current character is in the valid alphabet
                int idx = chr == "?" ? -1 : CharCode.IndexOf(chr, System.StringComparison.Ordinal);
                if (idx < 0)
                {
                    return false;
                }

                // Calculate power and convert to int
                idx = idx * (int)Math.Pow(2, i);
                num += idx;
            }
            num = (num % 11) % 10;

            // Return true if check digit equals num
            return Int32.Parse(containerCode.Substring(10, 1)) == num;
        }




        public static string ValidateCheckDigit(string equipmentNumber, int? checkDigit)
        {

            string Response = "Its Good";
            var AlphabetCodes = new Dictionary<char, int>();
            var PowerOfMultipliers = new List<int>(11);

            var step = 10;

            for (int i = 65; i < 91; i++)
            {
                char c = (char)i;
                int pos = i - 65 + step;
                if (c == 'A' || c == 'K' || c == 'U')
                    step += 1;

                AlphabetCodes.Add(c, pos);
            };

            for (int i = 0; i < 10; i++)
            {
                int result = (int)Math.Pow(2, i);
                PowerOfMultipliers.Add(result);
            };

            if (equipmentNumber.Length != 10)
            {
                Response = "Check Equipment Number Length";
                return Response;
            };

            if (checkDigit.ToString().Length != 1)
            {
                Response = "Check Check Digit Length";
                return Response;
            }

            string numCheckDigit = equipmentNumber + "" + checkDigit;
            {
                var total = 0;
                for (var i = 0; i < 10; i++)
                {
                    if (AlphabetCodes.ContainsKey(numCheckDigit[i]))
                        total += (AlphabetCodes[numCheckDigit[i]] * PowerOfMultipliers[i]);
                    else
                    {
                        var serialNumber = (int)numCheckDigit[i] - 48;
                        total += (serialNumber * PowerOfMultipliers[i]);
                    }
                }
                var testDigit = (int)total % 11;
                if (testDigit == 10)
                    testDigit = 0;
                if (testDigit != (int)numCheckDigit[10] - 48)
                {
                    Response = "Check Digit does not match number";
                    return Response;
                }

            }

            return Response;
        }


    }
}
