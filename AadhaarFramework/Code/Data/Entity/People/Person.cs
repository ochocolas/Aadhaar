using System;
using System.ComponentModel.DataAnnotations.Schema;
using AadhaarFramework.Code.Data.Entity.Common;
using AadhaarFramework.Code.Data.Entity.Process;

namespace AadhaarFramework.Code.Data.Entity.People
{
    /// <summary>
    /// The person class for enroll the population.
    /// </summary>
    public class Person : BaseEntity
    {
        /// <summary>
        /// Test data purpose.
        /// The probability of generate a random Member, Eye, finger.
        /// </summary>
        private static double _pMember = 0.99;
        /// <summary>
        /// Test data purpose.
        /// </summary>
        public static readonly string[] FemaleNames = new string[] {
                                                                 "	Aadhya	"
                                                                ,"	Aahana	"
                                                                ,"	Aalia	"
                                                                ,"	Aanya	"
                                                                ,"	Aaradhya	"
                                                                ,"	Aarna	"
                                                                ,"	Aarohi	"
                                                                ,"	Aditi	"
                                                                ,"	Advika	"
                                                                ,"	Adweta	"
                                                                ,"	Adya	"
                                                                ,"	Ahana	"
                                                                ,"	Akshara	"
                                                                ,"	Amaira	"
                                                                ,"	Amaya	"
                                                                ,"	Amrita	"
                                                                ,"	Amruta	"
                                                                ,"	Anaisha	"
                                                                ,"	Ananya	"
                                                                ,"	Anaya	"
                                                                ,"	Andrea	"
                                                                ,"	Angel	"
                                                                ,"	Anika	"
                                                                ,"	Anushka	"
                                                                ,"	Anvi	"
                                                                ,"	Anya	"
                                                                ,"	Aria	"
                                                                ,"	Arunima	"
                                                                ,"	Arya	"
                                                                ,"	Avni	"
                                                                ,"	Bhavna	"
                                                                ,"	Bhagyasri	"
                                                                ,"	Baghyawati	"
                                                                ,"	Bhanumati	"
                                                                ,"	Bhavani	"
                                                                ,"	Binita	"
                                                                ,"	Bishakha	"
                                                                ,"	Brinda	"
                                                                ,"	Bina	"
                                                                ,"	Bimala	"
                                                                ,"	Bhavini	"
                                                                ,"	Chaaya	"
                                                                ,"	Chaitaly	"
                                                                ,"	Chakrika	"
                                                                ,"	Chaman	"
                                                                ,"	Chameli	"
                                                                ,"	Chanchal	"
                                                                ,"	Chandani	"
                                                                ,"	Charita	"
                                                                ,"	Chasmum	"
                                                                ,"	Chavvi	"
                                                                ,"	Daksha	"
                                                                ,"	Dhriti	"
                                                                ,"	Divya	"
                                                                ,"	Diya	"
                                                                ,"	Dalaja	"
                                                                ,"	Damini	"
                                                                ,"	Damyanti	"
                                                                ,"	Darika	"
                                                                ,"	Dayamai	"
                                                                ,"	Dayita	"
                                                                ,"	Deepa	"
                                                                ,"	Ekaja	"
                                                                ,"	Ekani	"
                                                                ,"	Ekanta	"
                                                                ,"	Ekta	"
                                                                ,"	Ela	"
                                                                ,"	Eshana	"
                                                                ,"	Eta	"
                                                                ,"	Ekantika	"
                                                                ,"	Ella	"
                                                                ,"	Ekiya	"
                                                                ,"	Falguni	"
                                                                ,"	Forum	"
                                                                ,"	Faiza	"
                                                                ,"	Falak	"
                                                                ,"	Farisha	"
                                                                ,"	Fatheha	"
                                                                ,"	Farzeen	"
                                                                ,"	Farida	"
                                                                ,"	Gauri	"
                                                                ,"	Geet	"
                                                                ,"	Geetika	"
                                                                ,"	Ganga	"
                                                                ,"	Garima	"
                                                                ,"	Gaurangi	"
                                                                ,"	Garima	"
                                                                ,"	Gayathri	"
                                                                ,"	Gaurika	"
                                                                ,"	Gautami	"
                                                                ,"	Hiral	"
                                                                ,"	Harini	"
                                                                ,"	Hemangini	"
                                                                ,"	Hema	"
                                                                ,"	Harinakshi	"
                                                                ,"	Harita	"
                                                                ,"	Hemal	"
                                                                ,"	Hemani	"
                                                                ,"	Heena	"
                                                                ,"	Ira	"
                                                                ,"	Isha	"
                                                                ,"	Ishani	"
                                                                ,"	Ishanvi	"
                                                                ,"	Ishita	"
                                                                ,"	Idika	"
                                                                ,"	Idris	"
                                                                ,"	Ijaya	"
                                                                ,"	Ikshita	"
                                                                ,"	Indali	"
                                                                ,"	Jasmine	"
                                                                ,"	Jhanvi	"
                                                                ,"	Jagrati	"
                                                                ,"	Jagvi	"
                                                                ,"	Jalsa	"
                                                                ,"	Janaki	"
                                                                ,"	Januja	"
                                                                ,"	Janya	"
                                                                ,"	Jasmit	"
                                                                ,"	Jeevika	"
                                                                ,"	Jhalak	"
                                                                ,"	Kashvi	"
                                                                ,"	Kavya	"
                                                                ,"	Khushi	"
                                                                ,"	Kiara	"
                                                                ,"	Krisha	"
                                                                ,"	Krishna	"
                                                                ,"	Kyra	"
                                                                ,"	Kajal	"
                                                                ,"	Kamya	"
                                                                ,"	Kashika	"
                                                                ,"	Lakshmi	"
                                                                ,"	Lipika	"
                                                                ,"	Lolita	"
                                                                ,"	Lopa	"
                                                                ,"	Lekha	"
                                                                ,"	Leena	"
                                                                ,"	Libni	"
                                                                ,"	Lochan	"
                                                                ,"	Ladli	"
                                                                ,"	Lajita	"
                                                                ,"	Mahika	"
                                                                ,"	Manya	"
                                                                ,"	Maryam	"
                                                                ,"	Meera	"
                                                                ,"	Megha	"
                                                                ,"	Meghana	"
                                                                ,"	Meher	"
                                                                ,"	Mishka	"
                                                                ,"	Mitali	"
                                                                ,"	Myra	"
                                                                ,"	Naira	"
                                                                ,"	Navya	"
                                                                ,"	Nayantara	"
                                                                ,"	Niharika	"
                                                                ,"	Nisha	"
                                                                ,"	Nitara	"
                                                                ,"	Netra	"
                                                                ,"	Nidra	"
                                                                ,"	Nikita	"
                                                                ,"	Nilima	"
                                                                ,"	Olivia	"
                                                                ,"	Omaja	"
                                                                ,"	Omisha	"
                                                                ,"	Oni	"
                                                                ,"	Opal	"
                                                                ,"	Ojasvi	"
                                                                ,"	Omya	"
                                                                ,"	Osha	"
                                                                ,"	Odika	"
                                                                ,"	Oeshi	"
                                                                ,"	Pari	"
                                                                ,"	Pihu	"
                                                                ,"	Pratyusha	"
                                                                ,"	Prisha	"
                                                                ,"	Pahal	"
                                                                ,"	Palak	"
                                                                ,"	Panini	"
                                                                ,"	Pallavi	"
                                                                ,"	Parul	"
                                                                ,"	Pavani	"
                                                                ,"	Qushi	"
                                                                ,"	Qiyara	"
                                                                ,"	Quasar	"
                                                                ,"	Queeni	"
                                                                ,"	Quincy	"
                                                                ,"	Qayanat	"
                                                                ,"	Rachita	"
                                                                ,"	Raveena	"
                                                                ,"	Ridhi	"
                                                                ,"	Riya	"
                                                                ,"	Rabhya	"
                                                                ,"	Rachana	"
                                                                ,"	Radha	"
                                                                ,"	Rajata	"
                                                                ,"	Rajeshri	"
                                                                ,"	Raksha	"
                                                                ,"	Saanvi	"
                                                                ,"	Sahana	"
                                                                ,"	Sai	"
                                                                ,"	Saira	"
                                                                ,"	Samaira	"
                                                                ,"	Sarah	"
                                                                ,"	Saumya	"
                                                                ,"	Shanaya	"
                                                                ,"	Shravya	"
                                                                ,"	Shreya	"
                                                                ,"	Sneha	"
                                                                ,"	Suhana	"
                                                                ,"	Suhani	"
                                                                ,"	Tanvi	"
                                                                ,"	Trisha	"
                                                                ,"	Tanmayi	"
                                                                ,"	Tamanna	"
                                                                ,"	Tanuja	"
                                                                ,"	Tripti	"
                                                                ,"	Triveni	"
                                                                ,"	Triya	"
                                                                ,"	Turvi	"
                                                                ,"	Tulsi	"
                                                                ,"	Ucchal	"
                                                                ,"	Ubika	"
                                                                ,"	Udyati	"
                                                                ,"	Unnati	"
                                                                ,"	Unni	"
                                                                ,"	Upadhriti	"
                                                                ,"	Urishilla	"
                                                                ,"	Urmi	"
                                                                ,"	Upma	"
                                                                ,"	Upasna	"
                                                                ,"	Vaishnavi	"
                                                                ,"	Vansha	"
                                                                ,"	Vanya	"
                                                                ,"	Vedhika	"
                                                                ,"	Vinaya	"
                                                                ,"	Vamakshi	"
                                                                ,"	Vamika	"
                                                                ,"	Vasana	"
                                                                ,"	Vasatika	"
                                                                ,"	Vasudha	"
                                                                ,"	Waida	"
                                                                ,"	Warda	"
                                                                ,"	Wishi	"
                                                                ,"	Wafiya	"
                                                                ,"	Watika	"
                                                                ,"	Waheeda	"
                                                                ,"	Wajeeha	"
                                                                ,"	Wakeeta	"
                                                                ,"	Widisha	"
                                                                ,"	Yachana	"
                                                                ,"	Yadavi	"
                                                                ,"	Yahvi	"
                                                                ,"	Yashawini	"
                                                                ,"	Yashica	"
                                                                ,"	Yashoda	"
                                                                ,"	Yashodhara	"
                                                                ,"	Yasti	"
                                                                ,"	Yauvani	"
                                                                ,"	Yochana	"
                                                                ,"	Zara	"
                                                                ,"	Zoya	"
                                                                ,"	Zoey	"
                                                                ,"	Zora	"
                                                                ,"	Zuri	"
                                                                ,"	Zaha	"
                                                                ,"	Zaida	"
                                                                ,"	Zarna	"
                                                                ,"	Zenia	"
                                                                ,"	Zivah	"

        };
        /// <summary>
        /// Test data purpose.
        /// </summary>
        public static readonly string[] MaleNames = new string[] {
                                                                     "	Aadi	"
                                                                    ,"	Aarav	"
                                                                    ,"	Aarnav	"
                                                                    ,"	Aarush	"
                                                                    ,"	Aayush	"
                                                                    ,"	Abdul	"
                                                                    ,"	Abeer	"
                                                                    ,"	Abhimanyu	"
                                                                    ,"	Abhiramnew	"
                                                                    ,"	Aditya	"
                                                                    ,"	Advaith	"
                                                                    ,"	Advay	"
                                                                    ,"	Advik	"
                                                                    ,"	Agastya	"
                                                                    ,"	Akshay	"
                                                                    ,"	Amol	"
                                                                    ,"	Anay	"
                                                                    ,"	Anirudh	"
                                                                    ,"	Anmol	"
                                                                    ,"	Ansh	"
                                                                    ,"	Arin	"
                                                                    ,"	Arjun	"
                                                                    ,"	Arnav	"
                                                                    ,"	Aryan	"
                                                                    ,"	Atharv	"
                                                                    ,"	Avi	"
                                                                    ,"	Ayaan	"
                                                                    ,"	Ayush	"
                                                                    ,"	Ayushman	"
                                                                    ,"	Azaan	"
                                                                    ,"	Azad	"
                                                                    ,"	Brijesh	"
                                                                    ,"	Bachittar	"
                                                                    ,"	Bahadurjit	"
                                                                    ,"	Bakhshi	"
                                                                    ,"	Balendra	"
                                                                    ,"	Balhaar	"
                                                                    ,"	Baljiwan	"
                                                                    ,"	Balvan	"
                                                                    ,"	Balveer	"
                                                                    ,"	Banjeet	"
                                                                    ,"	Chaitanya	"
                                                                    ,"	Chakradev	"
                                                                    ,"	Chakradhar	"
                                                                    ,"	Champak	"
                                                                    ,"	Chanakya	"
                                                                    ,"	Chandran	"
                                                                    ,"	Chandresh	"
                                                                    ,"	Charan	"
                                                                    ,"	Chatresh	"
                                                                    ,"	Chatura	"
                                                                    ,"	Daksh	"
                                                                    ,"	Darsh	"
                                                                    ,"	Dev	"
                                                                    ,"	Devansh	"
                                                                    ,"	Dhruv	"
                                                                    ,"	Dakshesh	"
                                                                    ,"	Dalbir	"
                                                                    ,"	Darpan	"
                                                                    ,"	Ekansh	"
                                                                    ,"	Ekalinga	"
                                                                    ,"	Ekapad	"
                                                                    ,"	Ekavir	"
                                                                    ,"	Ekaraj	"
                                                                    ,"	Ekbal	"
                                                                    ,"	Farhan	"
                                                                    ,"	Falan	"
                                                                    ,"	Faqid	"
                                                                    ,"	Faraj	"
                                                                    ,"	Faras	"
                                                                    ,"	Fitan	"
                                                                    ,"	Fariq	"
                                                                    ,"	Faris	"
                                                                    ,"	Fiyaz	"
                                                                    ,"	Frado	"
                                                                    ,"	Gautam	"
                                                                    ,"	Gagan	"
                                                                    ,"	Gaurang	"
                                                                    ,"	Girik	"
                                                                    ,"	Girindra	"
                                                                    ,"	Girish	"
                                                                    ,"	Gopal	"
                                                                    ,"	Gaurav	"
                                                                    ,"	Gunbir	"
                                                                    ,"	Guneet	"
                                                                    ,"	Harsh	"
                                                                    ,"	Harshil	"
                                                                    ,"	Hredhaan	"
                                                                    ,"	Hardik	"
                                                                    ,"	Harish	"
                                                                    ,"	Hritik	"
                                                                    ,"	Hitesh	"
                                                                    ,"	Hemang	"
                                                                    ,"	Isaac	"
                                                                    ,"	Ishaan	"
                                                                    ,"	Imaran	"
                                                                    ,"	Indrajit	"
                                                                    ,"	Ikbal	"
                                                                    ,"	Ishwar	"
                                                                    ,"	Jainew	"
                                                                    ,"	Jason	"
                                                                    ,"	Jagdish	"
                                                                    ,"	Jagat	"
                                                                    ,"	Jatin	"
                                                                    ,"	Jai	"
                                                                    ,"	Jairaj	"
                                                                    ,"	Jeet	"
                                                                    ,"	Kabir	"
                                                                    ,"	Kalpit	"
                                                                    ,"	Karan	"
                                                                    ,"	Kiaan	"
                                                                    ,"	Krish	"
                                                                    ,"	Krishna	"
                                                                    ,"	Laksh	"
                                                                    ,"	Lakshay	"
                                                                    ,"	Lucky	"
                                                                    ,"	Lakshit	"
                                                                    ,"	Lohit	"
                                                                    ,"	Laban	"
                                                                    ,"	Manan	"
                                                                    ,"	Mohammed	"
                                                                    ,"	Madhav	"
                                                                    ,"	Mitesh	"
                                                                    ,"	Maanas	"
                                                                    ,"	Manbir	"
                                                                    ,"	Maanav	"
                                                                    ,"	Manthan	"
                                                                    ,"	Nachiket	"
                                                                    ,"	Naksh	"
                                                                    ,"	Nakul	"
                                                                    ,"	Neel	"
                                                                    ,"	Nakul	"
                                                                    ,"	Naveen	"
                                                                    ,"	Nihal	"
                                                                    ,"	Nitesh	"
                                                                    ,"	Om	"
                                                                    ,"	Ojas	"
                                                                    ,"	Omkaar	"
                                                                    ,"	Onkar	"
                                                                    ,"	Onveer	"
                                                                    ,"	Orinder	"
                                                                    ,"	Parth	"
                                                                    ,"	Pranav	"
                                                                    ,"	Praneel	"
                                                                    ,"	Pranit	"
                                                                    ,"	Pratyush	"
                                                                    ,"	Qabil	"
                                                                    ,"	Qadim	"
                                                                    ,"	Qarin	"
                                                                    ,"	Qasim	"
                                                                    ,"	Rachit	"
                                                                    ,"	Raghav	"
                                                                    ,"	Ranbir	"
                                                                    ,"	Ranveer	"
                                                                    ,"	Rayaan	"
                                                                    ,"	Rehaannew	"
                                                                    ,"	Reyansh	"
                                                                    ,"	Rishi	"
                                                                    ,"	Rohan	"
                                                                    ,"	Ronith	"
                                                                    ,"	Rudranew	"
                                                                    ,"	Rushil	"
                                                                    ,"	Ryan	"
                                                                    ,"	Sai	"
                                                                    ,"	Saksham	"
                                                                    ,"	Samaksh	"
                                                                    ,"	Samar	"
                                                                    ,"	Samarth	"
                                                                    ,"	Samesh	"
                                                                    ,"	Sarthak	"
                                                                    ,"	Sathviknew	"
                                                                    ,"	Shaurya	"
                                                                    ,"	Shivansh	"
                                                                    ,"	Siddharth	"
                                                                    ,"	Tejas	"
                                                                    ,"	Tanay	"
                                                                    ,"	Tanish	"
                                                                    ,"	Tarak	"
                                                                    ,"	Teerth	"
                                                                    ,"	Tanveer	"
                                                                    ,"	Udant	"
                                                                    ,"	Udarsh	"
                                                                    ,"	Utkarsh	"
                                                                    ,"	Umang	"
                                                                    ,"	Upkaar	"
                                                                    ,"	Vedant	"
                                                                    ,"	Veer	"
                                                                    ,"	Viaannew	"
                                                                    ,"	Vihaan	"
                                                                    ,"	Viraj	"
                                                                    ,"	Vivaan	"
                                                                    ,"	Wahab	"
                                                                    ,"	Wazir	"
                                                                    ,"	Warinder	"
                                                                    ,"	Warjas	"
                                                                    ,"	Wriddhish	"
                                                                    ,"	Wridesh	"
                                                                    ,"	Yash	"
                                                                    ,"	Yug	"
                                                                    ,"	Yatin	"
                                                                    ,"	Yuvraj	"
                                                                    ,"	Yagnesh	"
                                                                    ,"	Yatan	"
                                                                    ,"	Zayan	"
                                                                    ,"	Zaid	"
                                                                    ,"	Zayyan	"
                                                                    ,"	Zashil	"
                                                                    ,"	Zehaan	"

        };
        /// <summary>
        /// Test data purpose.
        /// </summary>
        public static readonly string[] Apellidos = new string[]
        {
"	Abbi	"
,"	Abhyankar	"
,"	Abraham	"
,"	Acharya	"
,"	Achrekar	"
,"	Adani	"
,"	Adhikane	"
,"	Adhikari	"
,"	Adiga	"
,"	Advani	"
,"	Agarkar	"
,"	Agarwal	"
,"	Agate	"
,"	Agnihotri	"
,"	Agvan	"
,"	Ahlawat	"
,"	Ahluwalia	"
,"	Ahuja	"
,"	Aiyappa	"
,"	Ajgaonkar	"
,"	Akash	"
,"	Akhtar	"
,"	Akkineni	"
,"	Ali	"
,"	Amarnath	"
,"	Ambani	"
,"	Ambedkar	"
,"	Ambekar	"
,"	Amble	"
,"	Ambuja	"
,"	Ambulkar	"
,"	Ameer	"
,"	Amin	"
,"	Amladi	"
,"	Amravatikar	"
,"	Amrutham	"
,"	Anand	"
,"	Anandi	"
,"	Anchan	"
,"	Anchan	"
,"	Aneja	"
,"	Annaladasula	"
,"	Antony	"
,"	Anumula	"
,"	Apdev	"
,"	Apte	"
,"	Apture	"
,"	Argade	"
,"	Arjun	"
,"	Arora	"
,"	Arya	"
,"	Ashar	"
,"	Asrani	"
,"	Asthana	"
,"	Ashtikar	"
,"	Atre	"
,"	Atrey	"
,"	Atri	"
,"	Attal	"
,"	Atwal	"
,"	Aulakh	"
,"	Avari	"
,"	Awasthi	"
,"	Babariya	"
,"	Babbar	"
,"	Babu	"
,"	Bachchan	"
,"	Badgujar	"
,"	Badkas	"
,"	Badhe	"
,"	Bahl	"
,"	Bhadsavle	"
,"	Bhaduri	"
,"	Bhasi	"
,"	Bafna	"
,"	Baghel	"
,"	Baid	"
,"	Bajaj	"
,"	Bajpai	"
,"	Bajwa	"
,"	Bakshi	"
,"	Balaji	"
,"	Balakrishnan	"
,"	Balasubramaniam	"
,"	Balsara	"
,"	Bamnote	"
,"	Bandodkar	"
,"	Bandyopadhyay	"
,"	Banerjee	"
,"	Bangera	"
,"	Bangre	"
,"	Banjan	"
,"	Bansal	"
,"	Bansod	"
,"	Banthia	"
,"	Banthiya	"
,"	Bantwal	"
,"	Bapat	"
,"	Barde	"
,"	Bardia	"
,"	Barman	"
,"	Barot	"
,"	Barua	"
,"	Basra	"
,"	Basu	"
,"	Batliwalla	"
,"	Batra	"
,"	Basha	"
,"	Bawaskar	"
,"	Baweja	"
,"	Bawre	"
,"	Bedi	"
,"	Bendre	"
,"	Benegal	"
,"	Bengre	"
,"	Berde	"
,"	Bhaiya	"
,"	Bhagat	"
,"	Bhagavathar	"
,"	Bhagwat	"
,"	Bhakri	"
,"	Bhalla	"
,"	Bhalodiya	"
,"	Bhan	"
,"	Bhandari	"
,"	Bhanot	"
,"	Bhanushali	"
,"	Bharadwaj	"
,"	Bhardwaj	"
,"	Bhargav	"
,"	Bharjatya	"
,"	Bharti	"
,"	Bhat	"
,"	Bhathheja	"
,"	Bhatia	"
,"	Bhattacharya	"
,"	Bhattad	"
,"	Bhatti	"
,"	Bhave	"
,"	Bhavsar	"
,"	Bhende	"
,"	Bhide	"
,"	Bhimani	"
,"	Bhite	"
,"	Bhoir	"
,"	Bhoite	"
,"	Bhojwani	"
,"	Bhosale	"
,"	Bhowmick	"
,"	Bhupathi	"
,"	Bhushan	"
,"	Bhuptani	"
,"	Bhutada	"
,"	Bijlani	"
,"	Bika	"
,"	Binny	"
,"	Birla	"
,"	Bisht	"
,"	Bisoi	"
,"	Biswas	"
,"	Biyani	"
,"	Bobde	"
,"	Bodhankar	"
,"	Bokare	"
,"	Bora	"
,"	Borgaonkar	"
,"	Borkar	"
,"	Bose	"
,"	Borisa	"
,"	Bradoo	"
,"	Buddharaju	"
,"	Budhisagar	"
,"	Bundela	"
,"	Burman	"
,"	Busanagari	"
,"	Buty	"
,"	Baishya	"
,"	Barhate	"
,"	Cethirakath	"
,"	Chabbria	"
,"	Chabukswar	"
,"	Chacko	"
,"	Chadha	"
,"	Chahal	"
,"	Chakole	"
,"	Chakraborty	"
,"	Chakravarthy	"
,"	Chanana	"
,"	Chanchad	"
,"	Chandani	"
,"	Chandavarkar	"
,"	Chandel	"
,"	Chander	"
,"	Chandak	"
,"	Chandok	"
,"	Chandorkar	"
,"	Chandrababu	"
,"	Channe	"
,"	Chafekar	"
,"	Chaphekar	"
,"	Chary	"
,"	Chattaraj	"
,"	Chatterjee	"
,"	Chattopadhyay	"
,"	Chaturvedi	"
,"	Chandra	"
,"	Chaubey	"
,"	Chauhan	"
,"	Chavan	"
,"	Chaurasiya	"
,"	Chaurasia	"
,"	Chawla	"
,"	Chedge	"
,"	Cheema	"
,"	Chettipally	"
,"	Chimalwar	"
,"	Chimote	"
,"	Chimurkar	"
,"	Chintawar	"
,"	Chitale	"
,"	Chitalia	"
,"	Chitnis	"
,"	Choksi	"
,"	Chopra	"
,"	Chorghade	"
,"	Chotai	"
,"	Choudhary	"
,"	Chaudhary	"
,"	Choudhury	"
,"	Chowdhury	"
,"	Chowdhary	"
,"	Chaudhari	"
,"	Chugh	"
,"	Chadaram	"
,"	Dabholkar	"
,"	Dabral	"
,"	Dadlani	"
,"	Daftari	"
,"	Daga	"
,"	Dahake	"
,"	Darekar	"
,"	Dalvi	"
,"	Damble	"
,"	Damle	"
,"	Dandale	"
,"	Dandekar	"
,"	Dang	"
,"	Dani	"
,"	Darbari	"
,"	Darji	"
,"	Darling	"
,"	Das	"
,"	Dasgupta	"
,"	Dasgupta	"
,"	Dashmunshi	"
,"	Daswani	"
,"	Datey	"
,"	Dave	"
,"	Dawande	"
,"	Dayal	"
,"	Dayma	"
,"	De	"
,"	Dedhe	"
,"	Dedhia	"
,"	Dehadrai	"
,"	Denzongpa	"
,"	Deodhar	"
,"	Deol	"
,"	Deora	"
,"	Desai	"
,"	Deshmukh	"
,"	Deshpande	"
,"	Dev	"
,"	Devadiga	"
,"	Devadikar	"
,"	Devaiah	"
,"	Devgade	"
,"	Devgan	"
,"	Dewaikar	"
,"	Dey	"
,"	Dhake	"
,"	Dhaliwal	"
,"	Dhameja	"
,"	Dhanoa	"
,"	Dhar	"
,"	Dharashiokar	"
,"	Dharmadhikari	"
,"	Dhawan	"
,"	Dhingra	"
,"	Dhillon	"
,"	Dholakia	"
,"	Dhone	"
,"	Dhoni	"
,"	Dhoot	"
,"	Dhote	"
,"	Dhumal	"
,"	Dhumale	"
,"	Dikshit	"
,"	Divekar	"
,"	Diwadkar	"
,"	Diwe	"
,"	Dixit	"
,"	Dobriyal	"
,"	Doifode	"
,"	Dongre	"
,"	Dosanjh	"
,"	Doshi	"
,"	Draboo	"
,"	Dua	"
,"	Dubey	"
,"	Duddala	"
,"	Dugar	"
,"	Duggal	"
,"	Dusanj	"
,"	Dutt	"
,"	Dutta	"
,"	Dwivedi	"
,"	Dande	"
,"	Doley	"
,"	Eknath	"
,"	Engle	"
,"	Faasil	"
,"	Fadikar	"
,"	Fadnavis	"
,"	Fansekar	"
,"	Faujdar	"
,"	Faye	"
,"	Fernandez	"
,"	Firodia	"
,"	Fotedar	"
,"	Gadde	"
,"	Gadekar	"
,"	Gadgil	"
,"	Ghadse	"
,"	Gadikar	"
,"	Gadkari	"
,"	Gadre	"
,"	Gaikwad	"
,"	Gaiki	"
,"	Gaitonde	"
,"	Gajjar	"
,"	Gambhir	"
,"	Ganatra	"
,"	Gandhi	"
,"	Ganesan	"
,"	Gangopadhyay	"
,"	Gangotra	"
,"	Ganguly	"
,"	Garach	"
,"	Garapati	"
,"	Garcia	"
,"	Garg	"
,"	Garware	"
,"	Gavaskar	"
,"	Gaur	"
,"	Gautam	"
,"	Gavit	"
,"	Gawande	"
,"	Gayatri	"
,"	Gehlot	"
,"	Gera	"
,"	Ghai	"
,"	Ghaisas	"
,"	Ghanekar	"
,"	Ghatate	"
,"	Ghate	"
,"	Ghosh	"
,"	Ghoshal	"
,"	Ghui	"
,"	Gilani	"
,"	Gill	"
,"	Girdhar	"
,"	Girotra	"
,"	Godbole	"
,"	Godse	"
,"	Goel	"
,"	Goenka	"
,"	Gohad	"
,"	Gohil	"
,"	Gokarn	"
,"	Gokhale	"
,"	Golani	"
,"	Gole	"
,"	Gopal	"
,"	Gopalan	"
,"	Gopi	"
,"	Gore	"
,"	Gosai	"
,"	Gosain	"
,"	Goswami	"
,"	Gounder	"
,"	Govind	"
,"	Govitrikar	"
,"	Gowarikar	"
,"	Gowda	"
,"	Goyal	"
,"	Grewal	"
,"	Grover	"
,"	Guha	"
,"	Gujar	"
,"	Gujral	"
,"	Gulgule	"
,"	Gulwadi	"
,"	Gunnam	"
,"	Gupta	"
,"	Gupte	"
,"	Gurnani	"
,"	Gursahani	"
,"	Gurwara	"
,"	Haasan	"
,"	Hadapsar	"
,"	Hadas	"
,"	Hagavane	"
,"	Haksar	"
,"	Handoo	"
,"	Hangal	"
,"	Hansraj	"
,"	Hardas	"
,"	Haridas	"
,"	Harode	"
,"	Hashmi	"
,"	Hasnee	"
,"	Hassan	"
,"	Hattangadi	"
,"	Hazra	"
,"	Hazare	"
,"	Hazari	"
,"	Hazarika	"
,"	Hebbar	"
,"	Hegde	"
,"	Hinduja	"
,"	Hingorani	"
,"	Hiranandani	"
,"	Hirani	"
,"	Hirlekar	"
,"	Hirwani	"
,"	Hiwre	"
,"	Hole	"
,"	Holkar	"
,"	Hooda	"
,"	Hoon	"
,"	Hoskote	"
,"	Huilgol	"
,"	Hundal	"
,"	Hanspal	"
,"	Hussainl	"
,"	Inamdar	"
,"	Indoria	"
,"	Indulkar	"
,"	Ingle	"
,"	Ingole	"
,"	Iragavarapu	"
,"	Irani	"
,"	Iraqi	"
,"	Ivaturi	"
,"	Iyengar	"
,"	Iyer	"
,"	Jadeja	"
,"	Jadhav	"
,"	Jadi	"
,"	Jadon	"
,"	Jagtap	"
,"	Jain	"
,"	Jaiswal	"
,"	Jajoo	"
,"	Jalan	"
,"	Janardhan	"
,"	Janefalkar	"
,"	Janmeja	"
,"	Janolkar	"
,"	Janumala	"
,"	Jariwala	"
,"	Jarthalia	"
,"	Jarthalya	"
,"	Jatasra	"
,"	Jawalkar	"
,"	Jena	"
,"	Jha	"
,"	Jhathar	"
,"	Jhawar	"
,"	Jindal	"
,"	Jinturkar	"
,"	Jobanputra	"
,"	Joglekar	"
,"	Johal	"
,"	Johar	"
,"	Joshi	"
,"	Juneja	"
,"	Juvekar	"
,"	kantharia	"
,"	Kadakia	"
,"	Kadam	"
,"	Kak	"
,"	Kakde	"
,"	Kalawar	"
,"	Kalbhor	"
,"	Kale	"
,"	Kalra	"
,"	Kalwani	"
,"	Kamat	"
,"	Kambli	"
,"	Kamboj	"
,"	Kanakia	"
,"	Kanchan	"
,"	Kane	"
,"	Kanetkar	"
,"	Kanhe	"
,"	Kanitkar	"
,"	Kankariya	"
,"	Kannaujiya	"
,"	Kanojiya	"
,"	Kanoongo	"
,"	Kansal	"
,"	Khaire	"
,"	Kapadia	"
,"	Kapoor	"
,"	Kapre	"
,"	Kapse	"
,"	Kapur	"
,"	Kar	"
,"	Karanth	"
,"	Karia	"
,"	Karkare	"
,"	Karkera	"
,"	Karlekar	"
,"	Karnad	"
,"	Karnatakkachu	"
,"	Karnawat	"
,"	Karnik	"
,"	Karthik	"
,"	Karwande	"
,"	Kasat	"
,"	Kasundra	"
,"	Katoch	"
,"	Kataria	"
,"	Kaul	"
,"	Kazi	"
,"	Kazmi	"
,"	Kelkar	"
,"	Keshari	"
,"	Kewalramani	"
,"	Khadse	"
,"	Khaitan	"
,"	Khan	"
,"	Khandar	"
,"	Khandelwal	"
,"	Khanduja	"
,"	Khanna	"
,"	Khanolkar	"
,"	Kharbanda	"
,"	Khatri	"
,"	Khedekar	"
,"	Khemu	"
,"	Kher	"
,"	Khetarpal	"
,"	Khobragade	"
,"	Kholkute	"
,"	Khopkar	"
,"	Khosla	"
,"	Khurana	"
,"	Kilachand	"
,"	Kinariwala	"
,"	Kinariwalla	"
,"	Kirloskar	"
,"	Kochar	"
,"	Koganti	"
,"	Kohale	"
,"	Kondke	"
,"	Kori	"
,"	Kothale	"
,"	Kothari	"
,"	Kotian	"
,"	Kottarakkara	"
,"	Kottary	"
,"	Kriplani	"
,"	Krishna	"
,"	Krishnamurthy	"
,"	Kuchibhotla	"
,"	Kukde	"
,"	Kukkar	"
,"	Kukreja	"
,"	Kukyan	"
,"	Kulkarni	"
,"	Kulshreshtha	"
,"	Kumari	"
,"	Kumbhare	"
,"	Kumble	"
,"	Kumpawat	"
,"	Kumta	"
,"	Kundar	"
,"	Kundra	"
,"	Kurien	"
,"	Kurup	"
,"	kathiriya	"
,"	Koshley	"
,"	Karpur	"
,"	Kabariya	"
,"	Lad	"
,"	Laddha	"
,"	Lagadapati	"
,"	Laghate	"
,"	Lagoo	"
,"	Lahoti	"
,"	Lakhani	"
,"	Lakhotia	"
,"	Lal	"
,"	Lalbhai	"
,"	Lalchandani	"
,"	Lallad	"
,"	Lalwani	"
,"	Lamba	"
,"	Langote	"
,"	Langroo	"
,"	Lapalikar	"
,"	Latkar	"
,"	Lele	"
,"	Ligam	"
,"	Limaye	"
,"	Lobo	"
,"	Lodha	"
,"	Lohia	"
,"	Lokhande	"
,"	Lopes	"
,"	Lote	"
,"	Ludhani	"
,"	Lunkad	"
,"	Luthra	"
,"	Loonaich	"
,"	Maan	"
,"	Mabiyan	"
,"	Madasani	"
,"	Madiwale	"
,"	Mafatlal	"
,"	Mahajan	"
,"	Mahakale	"
,"	Mahalingam	"
,"	Mahashabde	"
,"	Maheshwari	"
,"	Mahindra	"
,"	Mahindrakar	"
,"	Maitra	"
,"	Majumdar	"
,"	Makhija	"
,"	Makwana	"
,"	Malhan	"
,"	Malhotra	"
,"	Malhotra	"
,"	Mali	"
,"	Malik	"
,"	Malini	"
,"	Mallapur	"
,"	Mallya	"
,"	Malpe	"
,"	Malusare	"
,"	Malviya	"
,"	Mamdani	"
,"	Manak	"
,"	Manchandha	"
,"	Mandal	"
,"	Mandalik	"
,"	Mande	"
,"	Mandhane	"
,"	Mandlekar	"
,"	Manjrekar	"
,"	Marathe	"
,"	Marwah	"
,"	Marwaha	"
,"	Mashelkar	"
,"	Mathur	"
,"	Mathurkar	"
,"	Mattu	"
,"	Mayar	"
,"	Meghe	"
,"	Mehra	"
,"	Mehrotra	"
,"	Mehrotra	"
,"	Mehta	"
,"	Mendhi	"
,"	Mendon	"
,"	Menon	"
,"	Merchant	"
,"	Mhatre	"
,"	Minhas	"
,"	Mirchandani	"
,"	Mishra	"
,"	Mistry	"
,"	Mittal	"
,"	Mittal	"
,"	Modak	"
,"	Modi	"
,"	Moghe	"
,"	Mohan	"
,"	Mohanty	"
,"	Mohit	"
,"	Mohril	"
,"	Moitra	"
,"	Mojala	"
,"	Molkar	"
,"	Mongia	"
,"	More	"
,"	Morea	"
,"	Motwani	"
,"	Motwani	"
,"	Macwan	"
,"	Mudaliyar	"
,"	Mujawar	"
,"	Mujumdar	"
,"	Mukherjee	"
,"	Mulchandani	"
,"	Mule	"
,"	Muley	"
,"	Mulki	"
,"	Mundan	"
,"	Mundhe	"
,"	Mundi	"
,"	Munjal	"
,"	Munje	"
,"	Munshi	"
,"	Muralidharan	"
,"	Murthy	"
,"	Mushrif	"
,"	Muttemwar	"
,"	Muzumdar	"
,"	Noora	"
,"	Nabar	"
,"	Nadar	"
,"	Nadella	"
,"	Nadikatla	"
,"	Nadkarni	"
,"	Nag	"
,"	Nagaiah	"
,"	Nagar	"
,"	Nagpal	"
,"	Naik	"
,"	Nair	"
,"	Nakra	"
,"	Nalamolu	"
,"	Nambian	"
,"	Nambiar	"
,"	Nambiyar	"
,"	Namboodiri	"
,"	Nakhate	"
,"	Nanavati	"
,"	Nanda	"
,"	Nandamuri	"
,"	Nandanwar	"
,"	Nandigam	"
,"	Nanivadekar	"
,"	Nanoti	"
,"	Narang	"
,"	Narayan	"
,"	Narayanan	"
,"	Naresh	"
,"	Narlikar	"
,"	Narula	"
,"	Nath	"
,"	Nathawat	"
,"	Naudiyal	"
,"	Nawre	"
,"	Nayak	"
,"	Negi	"
,"	Nehra	"
,"	Nehru	"
,"	Nelluri	"
,"	Nene	"
,"	Nerurkar	"
,"	Nigade	"
,"	Nigam	"
,"	Nihalani	"
,"	Nikam	"
,"	Nike	"
,"	Nikhanj	"
,"	Nimbalkar	"
,"	Nimbark	"
,"	Nimhan	"
,"	Nischol	"
,"	Nitharwal	"
,"	Oak	"
,"	Oberoi	"
,"	Ogle	"
,"	Ogra	"
,"	Ohri	"
,"	Omble	"
,"	Omkareshwar	"
,"	Omkarnath	"
,"	Ozha	"
,"	Padukone	"
,"	Padwad	"
,"	Pahwa	"
,"	Pai	"
,"	Pagi	"
,"	Paintal	"
,"	Pal	"
,"	Palan	"
,"	Palande	"
,"	Palandurkar	"
,"	Palav	"
,"	Palekar	"
,"	Paliwal	"
,"	Palod	"
,"	Pancholi	"
,"	Panda	"
,"	Pande	"
,"	Pandey	"
,"	Pandher	"
,"	Pandhripande	"
,"	Pandian	"
,"	Pandit	"
,"	Pandya	"
,"	Pangarkar	"
,"	Page	"
,"	Pagey	"
,"	Panicker	"
,"	Panigrahi	"
,"	Panjwani	"
,"	Panse	"
,"	Pant	"
,"	Panthulu	"
,"	Panwar	"
,"	Pappu	"
,"	Papule	"
,"	Parab	"
,"	Paranjape	"
,"	Parasher	"
,"	Parate	"
,"	Parchure	"
,"	Pardesi	"
,"	Pardeshi	"
,"	Parekh	"
,"	Parihar	"
,"	Parikh	"
,"	Parkhi	"
,"	Parmar	"
,"	Parsodkar	"
,"	Paruchuri	"
,"	Pasricha	"
,"	Patankar	"
,"	Patekar	"
,"	Patel	"
,"	Pathak	"
,"	Patil	"
,"	Patki	"
,"	Patnaik	"
,"	Patne	"
,"	Patni	"
,"	Patra	"
,"	Patwardhan	"
,"	Paud	"
,"	Paul	"
,"	Pavri	"
,"	Pawar	"
,"	Pednekar	"
,"	Pendharkar	"
,"	Pendse	"
,"	Phanse	"
,"	Phatak	"
,"	Phogat	"
,"	Pillai	"
,"	Pimparkar	"
,"	Pimplapure	"
,"	Pingale	"
,"	Pinjarkar	"
,"	Piramal	"
,"	Piramal	"
,"	Pitale	"
,"	Pohankar	"
,"	Pohnekar	"
,"	Polekar	"
,"	Porwal	"
,"	Potdar	"
,"	Potdukhe	"
,"	Potluri	"
,"	Prabhavalkar	"
,"	Prabhu	"
,"	Pradhan	"
,"	Prajapati	"
,"	Prasad	"
,"	Prasade	"
,"	Prasadi	"
,"	Pratham	"
,"	Premji	"
,"	Punia	"
,"	Puniani	"
,"	Puniyani	"
,"	Punj	"
,"	Punwani	"
,"	Puram	"
,"	Puranik	"
,"	Puri	"
,"	Purohit	"
,"	Puthran	"
,"	Prakash	"
,"	Punetha	"
,"	Qazi	"
,"	Quereshi	"
,"	Qureshi	"
,"	Raaju	"
,"	Raaz	"
,"	Rahane	"
,"	Raheja	"
,"	Rahman	"
,"	Rai	"
,"	Raikantiwar	"
,"	Raina	"
,"	Rairakhia	"
,"	Raizada	"
,"	Raj	"
,"	Rajan	"
,"	Rajawat	"
,"	Rajpurohit	"
,"	Raju	"
,"	Rakshit	"
,"	Ramachandran	"
,"	Ramelwar	"
,"	Ramesh	"
,"	Ramisetty	"
,"	Ramnani	"
,"	Rampal	"
,"	Rana	"
,"	Ranade	"
,"	Ranawat	"
,"	Rane	"
,"	Rao	"
,"	Rastogi	"
,"	Rathi	"
,"	Rathod	"
,"	Rathore	"
,"	Ravinuthala	"
,"	Rawal	"
,"	Rawat	"
,"	Rawat	"
,"	Raxit	"
,"	Ray	"
,"	Raykantiwar	"
,"	Reddy	"
,"	Rege	"
,"	Rehman	"
,"	Reshammiya	"
,"	Rode	"
,"	Rokade	"
,"	Roshan	"
,"	Roy	"
,"	Roychoudhury	"
,"	Ruia	"
,"	Rungta	"
,"	Ruparel	"
,"	Rath	"
,"	Rumalla	"
,"	Sabnis	"
,"	Sachan	"
,"	Sachdev	"
,"	Sadarangani	"
,"	Sadhu	"
,"	Safary	"
,"	Saha	"
,"	Sahai	"
,"	Sahastrabuddhe	"
,"	Sahedev	"
,"	Sahni	"
,"	Sahu	"
,"	Sahukar	"
,"	Saigal	"
,"	Saini	"
,"	Saklani	"
,"	Sakpal	"
,"	Salian	"
,"	Salmaan	"
,"	Saluja	"
,"	Salunkhe	"
,"	Samarth	"
,"	Samdurkar	"
,"	Samudre	"
,"	Sandhu	"
,"	Sanghavi	"
,"	Sanghvi	"
,"	Sanil	"
,"	Sanir	"
,"	Sannidhi	"
,"	Sanon	"
,"	Saoji	"
,"	Sapra	"
,"	Saraf	"
,"	Sarda	"
,"	Saroha	"
,"	Sarnaik	"
,"	Sarode	"
,"	Sarve	"
,"	Sarwe	"
,"	Satam	"
,"	Satija	"
,"	Satpute	"
,"	Savarkar	"
,"	Sawant	"
,"	Sawarkar	"
,"	Sawhney	"
,"	Saw	"
,"	Saxena	"
,"	Sehgal	"
,"	Sehwag	"
,"	Sekhri	"
,"	Selvan	"
,"	Semwal	"
,"	Sen	"
,"	Sengupta	"
,"	Sethi	"
,"	Setna	"
,"	Shah	"
,"	Shahane	"
,"	Shareef	"
,"	Sharma	"
,"	Shastri	"
,"	Shekhawat	"
,"	Shelke	"
,"	Shenoy	"
,"	Sheikh	"
,"	Sheirgill	"
,"	Shekhar	"
,"	Sheshadri	"
,"	Shete	"
,"	Sheth	"
,"	Shetty	"
,"	Shikhavat	"
,"	Shikhawat	"
,"	Shinde	"
,"	Shirke	"
,"	Shishodia	"
,"	Shivalkar	"
,"	Shivdasani	"
,"	Shourey	"
,"	Shrikhande	"
,"	Shriyan	"
,"	Shroff	"
,"	Shukla	"
,"	Siddiqui	"
,"	Sidhu	"
,"	Sikarwar	"
,"	Simha	"
,"	Singh	"
,"	Singhal	"
,"	Singham	"
,"	Singhania	"
,"	Sinha	"
,"	Siripurapu	"
,"	Sirish	"
,"	Sobti	"
,"	Solanki	"
,"	Somaiya	"
,"	Somalwar	"
,"	Soman	"
,"	Somani	"
,"	Somayajulu	"
,"	Sonawane	"
,"	Soni	"
,"	Sharma	"
,"	Sonowal	"
,"	Sonpatki	"
,"	Sood	"
,"	Srinivasan	"
,"	Srivastava	"
,"	Subramaniam	"
,"	Subramanium	"
,"	Subramanyam	"
,"	Suchak	"
,"	Suman	"
,"	Surana	"
,"	Suri	"
,"	Surve	"
,"	Suvarna	"
,"	Suvariya	"
,"	Swamy	"
,"	Swarup	"
,"	Syed	"
,"	Sami	"
,"	Tadaskar	"
,"	Tagore	"
,"	Tahil	"
,"	Tahiliani	"
,"	Tahilramani	"
,"	Tak	"
,"	Talari	"
,"	Talgeri	"
,"	Talpade	"
,"	Talsania	"
,"	Talwar	"
,"	Tambe	"
,"	Tambke	"
,"	Tamang	"
,"	Tamhane	"
,"	Tamhankar	"
,"	Tandel	"
,"	Tandon	"
,"	Tanna	"
,"	Tanti	"
,"	Tanwar	"
,"	Taparia	"
,"	Tata	"
,"	Taurani	"
,"	Tawde	"
,"	Tayde	"
,"	Tejwani	"
,"	Tekchandani	"
,"	Tempalli	"
,"	Tendulkar	"
,"	Thackeray	"
,"	Thakersey	"
,"	Thakkar	"
,"	Thakore	"
,"	Thakral	"
,"	Thakran	"
,"	Thakre	"
,"	Thakrey	"
,"	Thakur	"
,"	Thakurtha	"
,"	Thapa	"
,"	Thapar	"
,"	Thombre	"
,"	Thorvi	"
,"	Thosar	"
,"	Thota	"
,"	Thuse	"
,"	Tijori	"
,"	Tikoo	"
,"	Tilak	"
,"	Tirodkar	"
,"	Tirpude	"
,"	Tiwari	"
,"	Tiwaskar	"
,"	Tomar	"
,"	Toor	"
,"	Tope	"
,"	Toshniwal	"
,"	Tripathi	"
,"	Trivedi	"
,"	Tufchi	"
,"	Tyagi	"
,"	Tapaniya	"
,"	Udayaraju	"
,"	Udyavar	"
,"	Ullal	"
,"	Umbarkar	"
,"	Unhale	"
,"	Uniyal	"
,"	Unni	"
,"	Unnikrishnan	"
,"	Unnithan	"
,"	Upadhyay	"
,"	Upadhye	"
,"	Upasni	"
,"	Uplenchwar	"
,"	Uppal	"
,"	Uppalapati	"
,"	Upponi	"
,"	Velugubanti	"
,"	Vaghela	"
,"	Vaida	"
,"	Vaidya	"
,"	Vaish	"
,"	Vajpayee	"
,"	Valecha	"
,"	Varghese	"
,"	Varma	"
,"	Vartak	"
,"	Vashisth	"
,"	Vasudevan	"
,"	Vaswani	"
,"	Vaze	"
,"	Veeranna	"
,"	Velankar	"
,"	Vengsarkar	"
,"	Venkat	"
,"	Venkateswaran	"
,"	Venkatraman	"
,"	Verghese	"
,"	Verma	"
,"	Vernekar	"
,"	Vichare	"
,"	Vidyarthi	"
,"	Vij	"
,"	Vijay	"
,"	Vijayrania	"
,"	Vincent	"
,"	Virani	"
,"	Virk	"
,"	Virmani	"
,"	Visariya	"
,"	Vora	"
,"	Vyas	"
,"	Wadekar	"
,"	Wadhavkar	"
,"	Wadhva	"
,"	Wadhawa	"
,"	Wadhawan	"
,"	Wadhwani	"
,"	Wadia	"
,"	Wagh	"
,"	Waghe	"
,"	Waghmare	"
,"	Waghray	"
,"	Wagle	"
,"	Waingankar	"
,"	Wajantri	"
,"	Waknis	"
,"	Walale	"
,"	Walawalakar	"
,"	Walia	"
,"	Walker	"
,"	Wangdu	"
,"	Wangnoo	"
,"	Wani	"
,"	Wanjare	"
,"	Wanjari	"
,"	Wankar	"
,"	Wankhede	"
,"	Waradpande	"
,"	Wargantiwar	"
,"	Warhadpande	"
,"	Warraich	"
,"	Warsi	"
,"	Watane	"
,"	Watharkar	"
,"	Wattal	"
,"	Watwe	"
,"	Wazalwar	"
,"	Wazir	"
,"	Yadav	"
,"	Yagnik	"
,"	Yarlagadda	"
,"	Yedekar	"
,"	Yederi	"
,"	Yelimeli	"
,"	Yelkar	"
,"	Yelpude	"
,"	Yenkie	"
,"	Yennemadi	"
,"	Yenugula	"
,"	Yeolekar	"
,"	Yerukola	"
,"	Yesuraju	"
,"	Zaantye	"
,"	Zade	"
,"	Zahaldar	"
,"	Zakaria	"
,"	Zalpuri	"
,"	Zarapkar	"
,"	Zariwala	"
,"	Zate	"
,"	Zaveri	"
,"	Zende	"
,"	Zite	"
,"	Zutshi	"
        };        
        /// <summary>
        /// Person first name.
        /// </summary>
        public string FirstName { get; set; } = String.Empty;
        /// <summary>
        /// Person middle name.
        /// </summary>
        public string MiddleName { get; set; } = String.Empty;
        /// <summary>
        /// Person Last name
        /// </summary>
        public string LastName { get; set; } = String.Empty;
        /// <summary>
        /// Person Birth date, the Age is calculated on the vwPopulation database view.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Address information
        /// </summary>
        public string HouseBuildingApartment { get; set; } = String.Empty;
        /// <summary>
        /// Address information
        /// </summary>
        public string StreetRoadLane { get; set; } = String.Empty;
        /// <summary>
        /// Address information
        /// </summary>
        public string Landmark { get; set; } = String.Empty;
        /// <summary>
        /// Address information
        /// </summary>
        public string AreaLocalitySector { get; set; } = String.Empty;
        /// <summary>
        /// Address information
        /// </summary>
        public string VillageTownCity { get; set; } = String.Empty;
        /// <summary>
        /// Country area, by default 91, since Aadhaar is for people that lives in India like foreigners.
        /// </summary>
        public string CountryArea { get; set; } = "91"; //para india
        /// <summary>
        /// Phone number.
        /// </summary>
        public string PhoneNumber { get; set; } = String.Empty;
        /// <summary>
        /// Person Email.
        /// </summary>
        public string Email { get; set; } = String.Empty;
        /// <summary>
        /// Gender Of the person.
        /// </summary>
        public long IdGender { get; set; }
        /// <summary>
        /// Religion of the Person.
        /// </summary>
        public long IdReligion { get; set; }

        /// <summary>
        /// State where the Person live.
        /// </summary>
        public long IdState { get; set; }
        /// <summary>
        /// Who was the enroller that enroll the person.
        /// </summary>
        public long IdEnroller { get; set; }
        /// <summary>
        /// Language of the person.
        /// </summary>
        public long IdLanguage { get; set; }
        /// <summary>
        /// A flag for the person if is desceased, it will not be deleted.
        /// </summary>
        public bool IsDesceased { get; set; }
        /// <summary>
        /// A flag for statistical purposes to check how many duplicateds are enrolled.
        /// </summary>
        public bool IsDuplicated { get; set; }
        #region "Data biometrica"
        /// <summary>
        /// Optional Photography, PersonProvider prevents nulls.
        /// </summary>
        public long? IdPhotography { get; set; }
        /// <summary>
        /// Optional Eye, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdIrisLeftEye { get; set; } = null;
        /// <summary>
        /// Optional Eye, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdIrisRightEye { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintLeftHandThumb { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintLeftHandIndex { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintLeftHandMiddle { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintLeftHandRing { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintLeftHandPinky { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintRightHandThumb { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintRightHandIndex { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintRightHandMiddle { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintRightHandRing { get; set; } = null;
        /// <summary>
        /// Optional Fingerprint, PersonProvider prevents by checking at least one biometric data (there should be someone out there, where has lost his/her arms and maybe one Eye).
        /// </summary>
        public long? IdFingerPrintRightHandPinky { get; set; } = null;

        #endregion
        #region "Personal data"
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdGender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdReligion")]
        public Religion Religion { get; set; }

        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdState")]
        public State State { get; set; }

        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdLanguage")]
        public Language Language { get; set; }
        #endregion
        #region "Biometric data"
        #region "Personal face data"
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdPhotography")]
        public Photography Photography { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdIrisLeftEye")]
        public Eye IrisLeftEye { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdIrisRightEye")]
        public Eye IrisRightEye { get; set; }

        #endregion
        #region "Personal hand data"
        #region "Personal Left Hand Data"
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintLeftHandThumb")]
        public FingerPrint FingerPrintLeftHandThumb { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintLeftHandIndex")]
        public FingerPrint FingerPrintLeftHandIndex { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintLeftHandMiddle")]
        public FingerPrint FingerPrintLeftHandMiddle { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintLeftHandRing")]
        public FingerPrint FingerPrintLeftHandRing { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintLeftHandPinky")]
        public FingerPrint FingerPrintLeftHandPinky { get; set; }
        #endregion

        #region "personal right hand data"
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintRightHandThumb")]
        public FingerPrint FingerPrintRightHandThumb { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintRightHandIndex")]
        public FingerPrint FingerPrintRightHandIndex { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintRightHandMiddle")]
        public FingerPrint FingerPrintRightHandMiddle { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintRightHandRing")]
        public FingerPrint FingerPrintRightHandRing { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdFingerPrintRightHandPinky")]
        public FingerPrint FingerPrintRightHandPinky { get; set; }
        #endregion

        #endregion
        #endregion


        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdEnroller")]
        public Enroller Enroller { get; set; }

        /// <summary>
        /// Provides validation functionallity if this.object has at least one Eye
        /// </summary>
        /// <returns></returns>
        public bool DoesItHaveAtLeastOneEye()
        {
            long? tmp =  (IdIrisLeftEye == null ? 0 : IdIrisLeftEye )
                       + (IdIrisRightEye == null ? 0 : IdIrisRightEye);
            if (tmp == null)
                tmp = 0;

            if (tmp > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Provides validation functionallity if this.object has at least one finger.
        /// </summary>
        /// <returns></returns>
        public bool DoesItHaveAtLeastOneFinger()
        {
            long? tmp = (IdFingerPrintLeftHandThumb == null ? 0 : IdFingerPrintLeftHandThumb)
                      + (IdFingerPrintLeftHandIndex == null ? 0 : IdFingerPrintLeftHandIndex)
                      + (IdFingerPrintLeftHandMiddle == null ? 0 : IdFingerPrintLeftHandMiddle)
                      + (IdFingerPrintLeftHandRing == null ? 0 : IdFingerPrintLeftHandRing)
                      + (IdFingerPrintLeftHandPinky == null ? 0 : IdFingerPrintLeftHandPinky)
                      + (IdFingerPrintRightHandThumb == null ? 0 : IdFingerPrintRightHandThumb)
                      + (IdFingerPrintRightHandIndex == null ? 0 : IdFingerPrintRightHandIndex)
                      + (IdFingerPrintRightHandMiddle == null ? 0 : IdFingerPrintRightHandMiddle)
                      + (IdFingerPrintRightHandRing == null ? 0 : IdFingerPrintRightHandRing)
                      + (IdFingerPrintRightHandPinky == null ? 0 : IdFingerPrintRightHandPinky);
            if (tmp == null)
                tmp = 0;

            if (tmp > 0)
                return true;

            return false;

        }
        /// <summary>
        /// Generate test date, filling the fields with it.
        /// </summary>
        public void GenerateRandomPerson()
        {
            Random rnd = new Random();
            int IdGender = rnd.Next(1, Gender.Genders.Length);

            int IdFirstName = 0;
            int IdMiddleName = 0;
            int IdLastName = 0;
            int IdReligion = 0;
            int IdState = 0;
            int IdEnroller = 0;
            int IdLanguage = 0;
            string FirstName = "";
            string MiddleName = "";

            DateTime BirthDate;
            if (IdGender == 1)
            {
                IdFirstName = rnd.Next(MaleNames.Length);
                IdMiddleName = rnd.Next(MaleNames.Length);
                FirstName = MaleNames[IdFirstName].Replace(System.Environment.NewLine, String.Empty).Trim();
                MiddleName = MaleNames[IdMiddleName].Replace(System.Environment.NewLine, String.Empty).Trim();
            }
            else
            {
                IdFirstName = rnd.Next(FemaleNames.Length);
                IdMiddleName = rnd.Next(FemaleNames.Length);
                FirstName = FemaleNames[IdFirstName].Replace(System.Environment.NewLine, String.Empty).Trim();
                MiddleName = FemaleNames[IdMiddleName].Replace(System.Environment.NewLine, String.Empty).Trim();
            }

            IdLastName = rnd.Next(Apellidos.Length);


            DateTime start = new DateTime(DateTime.Now.Year - 100, 1, 1);
            int range = (DateTime.Today - start).Days;
            BirthDate = start.AddDays(rnd.Next(range));

            DateTime CreateDate = new DateTime(DateTime.Now.Year, 5, 1);
            DateTime ModifyDate = new DateTime(CreateDate.Year, 5, 1);
            range = (DateTime.Today - CreateDate).Days;
            CreateDate = CreateDate.AddDays(rnd.Next(range));
            range = (DateTime.Today - CreateDate).Days;
            ModifyDate = CreateDate.AddDays(rnd.Next(range));
            IdReligion = rnd.Next(1, Religion.Religions.Length);
            IdState = rnd.Next(1, State.States.Count);
            IdEnroller = rnd.Next(1, Enroller.Enrollers.Length);

            IdLanguage = rnd.Next(1, Language.Languages.Length);
            //genero fotografia aleatoria
            Photography Photography = new Photography();
            Photography.Photo = Photography.GenerateTestPhotography();

            //Genero Iris y huellas aleatorias


            Eye LeftEye = new Eye();
            LeftEye.Iris = LeftEye.GenerateTestIris();

            Eye RightEye = new Eye();
            RightEye.Iris = RightEye.GenerateTestIris();

            FingerPrint LeftThumb = new FingerPrint();
            LeftThumb.Finger = LeftThumb.GenerateTestFinger();

            FingerPrint LeftIndex = new FingerPrint();
            LeftIndex.Finger = LeftThumb.GenerateTestFinger();

            FingerPrint LeftMiddle = new FingerPrint();
            LeftMiddle.Finger = LeftThumb.GenerateTestFinger();

            FingerPrint LeftRing = new FingerPrint();
            LeftRing.Finger = LeftThumb.GenerateTestFinger();

            FingerPrint LeftPinky = new FingerPrint();
            LeftPinky.Finger = LeftThumb.GenerateTestFinger();


            FingerPrint RightThumb = new FingerPrint();
            RightThumb.Finger = RightThumb.GenerateTestFinger();

            FingerPrint RightIndex = new FingerPrint();
            RightIndex.Finger = RightThumb.GenerateTestFinger();

            FingerPrint RightMiddle = new FingerPrint();
            RightMiddle.Finger = RightThumb.GenerateTestFinger();

            FingerPrint RightRing = new FingerPrint();
            RightRing.Finger = RightThumb.GenerateTestFinger();

            FingerPrint RightPinky = new FingerPrint();
            RightPinky.Finger = RightThumb.GenerateTestFinger();


            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = Apellidos[IdLastName].Replace(System.Environment.NewLine, String.Empty).Trim();
            this.BirthDate = BirthDate;
            this.IdGender = IdGender;
            this.IdReligion = IdReligion;
            this.IdState = IdState;
            this.IdEnroller = IdEnroller;
            this.IdLanguage = IdLanguage;
            this.Photography = Photography;

            this.IdIrisLeftEye = 1;
            this.IrisLeftEye = LeftEye; 
            if (DoIGenerateRandomMember()) { this.IdIrisRightEye = 1; this.IrisRightEye = RightEye; }

            if (DoIGenerateRandomMember()) { this.IdFingerPrintLeftHandThumb = 1;  this.FingerPrintLeftHandThumb = LeftThumb; }
            if (DoIGenerateRandomMember()) { this.IdFingerPrintLeftHandIndex = 1; this.FingerPrintLeftHandIndex = LeftIndex; }
            if (DoIGenerateRandomMember()) { this.IdFingerPrintLeftHandMiddle = 1; this.FingerPrintLeftHandMiddle = LeftMiddle; }
            if (DoIGenerateRandomMember()) { this.IdFingerPrintLeftHandRing = 1; this.FingerPrintLeftHandRing = LeftRing; }
            if (DoIGenerateRandomMember()) { this.IdFingerPrintLeftHandPinky = 1; this.FingerPrintLeftHandPinky = LeftPinky; }

            if (DoIGenerateRandomMember()) { this.IdFingerPrintRightHandThumb = 1; this.FingerPrintRightHandThumb = RightThumb; }
            if (DoIGenerateRandomMember()) { this.IdFingerPrintRightHandIndex = 1; this.FingerPrintRightHandIndex = RightIndex; }
            if (DoIGenerateRandomMember()) { this.IdFingerPrintRightHandMiddle = 1; this.FingerPrintRightHandMiddle = RightMiddle; }
            if (DoIGenerateRandomMember()) { this.IdFingerPrintRightHandRing = 1; this.FingerPrintRightHandRing = RightRing; }
            if (DoIGenerateRandomMember()) { this.IdFingerPrintRightHandPinky = 1; this.FingerPrintRightHandPinky = RightPinky; }
            this.CreatedDate = CreateDate;
            this.ModifyDate = ModifyDate;
            this.ModifyBy = "sys_admin";
        }
        /// <summary>
        /// Provides funcionallity in the generation of random data for this object.
        /// </summary>
        /// <returns>true if it should generate a fingerprint or an eye. False if not.
        /// </returns>
        private bool DoIGenerateRandomMember()
        {
            double RandomMember;
            Random rnd = new Random();
            RandomMember = rnd.NextDouble();
            return !(RandomMember > _pMember);
        }
    }
}
