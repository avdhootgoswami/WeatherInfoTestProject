/************** NOTES *********************************/
Configuration : Website, Browser, Location info is read from the app.config file

Test Case : TestCompareTodayTomorrowHumidityForALocationForATime
Comments  : 1. This test case shows output as part of test result log 
			2. No assert criterias are added to the test case. 
               If needed assert criteria's from test case 'TestSearchWeatherForALocation' can be used
            3. Commented lines having Console.WriteLine() are used for debugging purposes.
			   (Note - I feel that unnecessary comments such as these should no be part of the production code. These should be removed from code)
			

Sample Output for Test Case:
---------------------------------------------------------------------------
Test Name:	TestCompareTodayTomorrowHumidityForALocationForATime
Test Outcome:	Passed
Result StandardOutput:	
Humidity for 2019-12-11 for 08:00 hr is : 92
Humidity for 2019-12-12 for 08:00 hr is : 90
Difference in humidity is : 2

---------------------------------------------------------------------------
---------------------------------------------------------------------------

Sample output (with debug lines enabled) for Test Case:
---------------------------------------------------------------------------
Test Name:	TestCompareTodayTomorrowHumidityForALocationForATime
Test Outcome:	Passed
Result StandardOutput:	
Humidity data for: 2019-12-11
| Hour     | Humidity | XPath                                                                                               
------------------------------------------------------------------------
| Now      | 92       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[1]//span                       
| 09:00    | 88       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[2]//span                       
| 10:00    | 85       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[3]//span                       
| 11:00    | 82       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[4]//span                       
| 12:00    | 79       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[5]//span                       
| 13:00    | 76       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[6]//span                       
| 14:00    | 79       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[7]//span                       
| 15:00    | 83       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[8]//span                       
| 16:00    | 85       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[9]//span                       
| 17:00    | 87       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[10]//span                      
| 18:00    | 88       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[11]//span                      
| 19:00    | 89       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[12]//span                      
| 20:00    | 89       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[13]//span                      
| 21:00    | 89       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[14]//span                      
| 22:00    | 89       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[15]//span                      
| 23:00    | 91       | //div[@id='2019-12-11']//tr[@class='detailed-view step-humidity']//td[16]//span                      
------------------------------------------------------------------------
Humidity data for: 2019-12-12
| Hour     | Humidity | XPath                                                                                               
------------------------------------------------------------------------
| 00:00    | 89       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[1]//span                       
| 01:00    | 90       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[2]//span                       
| 02:00    | 91       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[3]//span                       
| 03:00    | 92       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[4]//span                       
| 04:00    | 93       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[5]//span                       
| 05:00    | 93       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[6]//span                       
| 06:00    | 92       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[7]//span                       
| 07:00    | 92       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[8]//span                       
| 08:00    | 90       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[9]//span                       
| 09:00    | 89       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[10]//span                      
| 10:00    | 91       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[11]//span                      
| 11:00    | 93       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[12]//span                      
| 12:00    | 93       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[13]//span                      
| 13:00    | 93       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[14]//span                      
| 14:00    | 93       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[15]//span                      
| 15:00    | 94       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[16]//span                      
| 16:00    | 94       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[17]//span                      
| 17:00    | 94       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[18]//span                      
| 18:00    | 94       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[19]//span                      
| 19:00    | 94       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[20]//span                      
| 20:00    | 94       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[21]//span                      
| 21:00    | 92       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[22]//span                      
| 22:00    | 92       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[23]//span                      
| 23:00    | 89       | //div[@id='2019-12-12']//tr[@class='detailed-view step-humidity']//td[24]//span                      
------------------------------------------------------------------------
Humidity for 2019-12-11 for 08:00 hr is : 92
Humidity for 2019-12-12 for 08:00 hr is : 90
Difference in humidity is : 2








