using System.Collections.Generic;
using UnityEngine;

public class WordsDB : MonoBehaviour
{
    ////Romania 
    //public static Category[] categoriesRO = new Category[]
    //{
    //    #region Început
    //    new Category
    //    {
    //       categoryName = "Început",
    //       detailIndex = 0,
    //       words = new Word[]
    //       {
    //            new Word {
    //                wordText = "Altex",
    //                hint = "Magazin de electronice",
    //                startYear = 1992,
    //                about = "Altex este o companie din România, cu sediul în Voluntari, care comercializează produse electronice, electrocasnice, cosmetice, articole de îngrijire personală... În februarie 2018, compania avea 128 de magazine (dintre care 19 sunt unități Media Galaxy). Principalul concurent este Flanco."
    //            },
    //       },
    //    },
    //    #endregion

    //    #region Magazine & Restaurante
    //    new Category
    //     {
    //        categoryName = "Magazine & Restaurante",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "Vivo",
    //                hint = "Mall"
    //            },
    //            new Word {
    //                wordText = "Afi",
    //                hint = "Mall"
    //            },
    //            new Word {
    //                wordText = "Băneasa",
    //                hint = "Mall"
    //            },
    //            new Word {
    //                wordText = "Cărturești",
    //                hint = "Librărie",
    //                startYear = 2000,
    //                about = "Cărturești este o companie care deține o rețea de 12 librării în România. Cărtureşti a primit premiul Superbrands Romania, pentru performanţe excepţionale în branding, în anii 2008, 2009 şi 2013"
    //            },
    //            new Word {
    //                wordText = "Catena",
    //                hint = "Farmacie",
    //                startYear = 1999,
    //                about = "Catena este cel mai mare lanț de farmacii din România, deținut de grupul Fildas."
    //            },
    //            new Word {
    //                wordText = "Tucano",
    //                hint = "Cafenea",
    //                startYear = 2010,
    //            },
    //            new Word {
    //                wordText = "Profi",
    //                hint = "Supermarket",
    //                startYear = 1979,
    //                about = "Profi este un lanț de supermarketuri și magazine de proximitate în România, deținut de către fondul de investiții Mid Europa Partners."
    //            },
    //            new Word {
    //                wordText = "Flanco",
    //                hint = "Electronice, electrocasnice, IT&C",
    //                startYear = 1990,
    //                about="Flanco este o rețea de magazine de produse electronice, electrocasnice și IT&C din România. Compania a fost înființată de omul de afaceri Florin Andronescu, iar numele Flanco vine de la Florin Andronescu Company."
    //            },
    //            new Word {
    //                wordText = "Mega Image",
    //                hint = "Supermarket",
    //                startYear = 1995,
    //                about = "Mega Image este un lanț de supermarketuri si magazine de proximitate din România, fondat în București în 1995. În anul 2015 existau 704 magazine în țară."
    //            },
    //            new Word {
    //                wordText = "Dedeman",
    //                hint = "Magazin de scule",
    //                startYear = 1992,
    //                about = "Dedeman este o companie din orașul Bacău, România care se ocupă cu vânzarea de materiale de construcții și amenajări interioare."
    //            },
    //            new Word {
    //                wordText = "LaDoiPași",
    //                hint = "Supermarket",
    //                startYear = 2012,
    //                about = "La Doi Pași este o franciză de magazine de proximitate lansată de compania Metro. Brandul reunește peste 1000 de magazine, deținute de mici comercianți independenți, majoritatea în orașe mici și comune."
    //            },
    //            new Word {
    //                wordText = "Mobexpert",
    //                hint = "magazin de mobilă",
    //                startYear = 1993,
    //                about = "Grupul Mobexpert este liderul pe piața de mobilier din România. Mobexpert se clasează între primele douăsprezece întreprinderi europene din industria mobilei."
    //            },
    //            new Word {
    //                wordText = "Filicori",
    //                hint = "Cafenea",
    //                startYear = 1919,
    //            },
    //            new Word {
    //                wordText = "5 To Go",
    //                hint = "Cafenea",
    //                about = "5 to go este cel mai mare lanț de cafenele din Europa de Est și cea mai accesată franciză din România. Brandul 100% românesc e prezent în peste 140 de locații la momentul actual, în București și în alte 17 orașe din țară."
    //            },
    //        },

    //        bonusWords = new Word[]
    //        {
    //            new Word {
    //                wordText = "Annabella",
    //                hint = "Supermarket",
    //                startYear = 1994,
    //                isGuess = true,
    //                variants = new List<string>{ "Alabella", "Balabella", "Sanabella"},
    //                about = "Sub numele Annabella funcţionează azi nu mai puţin de 90 de magazine răspândite în tot judeţul Vâlcea şi nu numai. Annabella a dedicat segmentului alimentar, o proporție de 75% din spațiul său, restul fiind ocupat de produse non alimentare." }
    //        }
    //     },
    //    #endregion

    //    #region Aplicații & Site-uri
    //    new Category
    //     {
    //        categoryName = "Aplicații & Site-uri",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "Autovit",
    //                hint = "Vânzări auto second-hand",
    //                startYear = 2000,
    //                about = "Autovit.ro este cel mai mare site de vânzări de mașini second-hand din România."
    //            },
    //            new Word {
    //                wordText = "CEL.ro",
    //                hint = "Tehnologie",
    //                startYear = 2005,
    //                about = "CEL.ro este un magazin online de IT&C cu sediul în București, administrat în prezent de compania Corsar Online SRL cu capital 100% românesc."
    //            },
    //            new Word {
    //                wordText = "Trilulilu",
    //                hint = "Amuzament",
    //                startYear = 2007,
    //                about = "Trilulilu a fost site web românesc care dedicat pentru încărcarea fișierelor video și fișierelor de tip audio și imagini. În august 2010, Trilulilu era al doilea site din România ca număr de accesări (după Hi5)."
    //            },
    //            new Word {
    //                wordText = "Libertatea",
    //                hint = "Ziar",
    //                startYear = 1989,
    //                about = "Libertatea este un ziar din România, care publică articole din domenii precum social, știri, entertainment și lifestyle. A fost fondat în 22 decembrie 1989, devenind astfel ”primul ziar independent al Revoluției Române din 1989"
    //            },
    //            new Word {
    //                wordText = "Mercador.ro",
    //                hint = "Secondhand",
    //                startYear = 2006,
    //                about = "In 2014, Mercador.ro, isi schimba numele in OLX.ro printr-un proces de rebranding la nivelul grupului Naspers."
    //            },
    //            new Word {
    //                wordText = "Emag",
    //                hint = "Tehnologie"
    //            },
    //            new Word {
    //                wordText = "Trivago",
    //                hint = "Hotel?"
    //            },
    //            new Word {
    //                wordText = "Elefant",
    //                hint = "Magazin online",

    //            },
    //            new Word {
    //                wordText = "Publi24",
    //                hint = "Secondhand"
    //            },
    //            new Word {
    //                wordText = "LaJumate.ro",
    //                hint = ""
    //            },
    //            new Word {
    //                wordText = "eJobs",
    //                hint = "Locuri de muncă"
    //            },
    //            new Word {
    //                wordText = "YOXO",
    //                hint = "Telecomunicații mobile"
    //            },
    //            new Word {
    //                wordText = "Tazz",
    //                hint = "Livrare de mâncare"
    //            },
    //            new Word {
    //                wordText = "ABOUT YOU",
    //                hint = "Îmbrăcăminte și accesorii"
    //            },
    //            new Word {
    //                wordText = "HotNews",
    //                hint = "Știri"
    //            },
    //            new Word {
    //                wordText = "Softpedia",
    //                hint = "Forum"
    //            },
    //            new Word {
    //                wordText = "AntenaPlay",
    //                hint = "",
    //            },
    //            new Word {
    //                wordText = "Playtech",
    //                hint = "Știri despre tehnologie"
    //            },
    //            new Word {
    //                wordText = "Sport.ro",
    //                hint = "Știri sportive"
    //            },
    //            new Word {
    //                wordText = "GSP.ro",
    //                hint = "Știri sportive"
    //            },
    //            new Word {
    //                wordText = "Mobilissimo",
    //                hint = "Știri despre tehnologie"
    //            },
    //            new Word {
    //                wordText = "Voyo",
    //                hint = ""
    //            },
    //        },

    //        bonusWords = new Word[]
    //        {
    //            new Word {
    //                wordText = "BlaBlaCar",
    //                hint = "Rideshareing",
    //                isGuess = true,
    //                variants = new List<string>{ "VlaVlaCar", "LaLaCar", "Vruum"}
    //            }
    //        }
    //     },
    //    #endregion

    //    #region YouTube & Muzică
    //    new Category
    //     {
    //        categoryName = "YouTube & Muzică",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "BUG Mafia",
    //                hint = "Trupă de muzică",
    //                startYear = 1993,
    //                about = "B.U.G. Mafia este o trupă de hip-hop din România fondată în anul 1993. Actualii componenți sunt Tataee, Caddy și Uzzi."
    //            },
    //            new Word {
    //                wordText = "Neversea",
    //                hint = "Festival de muzică",
    //                startYear = 2017,
    //                about = "Neversea Festival este cel mai mare festival de muzică care are loc pe o plajă din România. Acesta se desfășoară în fiecare an pe Neversea Beach din Constanța, în apropierea plajei Modern."
    //            },
    //            new Word {
    //                wordText = "Untold",
    //                hint = "Festival de muzică",
    //                startYear = 2015,
    //                about = "Untold Festival este cel mai mare festival de muzică din România. Acesta se desfășoară în fiecare an pe Cluj Arena în orașul Cluj Napoca."
    //            },
    //            new Word {
    //               wordText = "Romexpo",
    //               hint = "Centru expozițional",
    //               startYear = 1962,
    //               about = "ROMEXPO, cel mai important centru expozițional din București și din România, reprezintă punctul de referință pentru toate evenimentele românești."
    //            },
    //            new Word { wordText = "Nek Music", hint = "Muzică", },
    //            new Word { wordText = "Roton", hint = "Muzică" },
    //            new Word { wordText = "Cat Music", hint = "Muzică" },
    //            new Word { wordText = "Trapanele", hint = "Muzică" },

    //            new Word { wordText = "Bratu Art", hint = "Desen" },

    //            new Word { wordText = "iRaphahell", hint = "Gaming" },
    //            new Word { wordText = "iHatePink", hint = "Gaming" },
    //            new Word { wordText = "Jamila", hint = "Gaming" },
    //            new Word { wordText = "MaxINFINITE", hint = "Gaming" },
    //            new Word { wordText = "Gannicus96", hint = "Gaming" },
    //        }
    //     },
    //     #endregion
              
    //    #region Cosmetice & Îngrijire
    //     new Category
    //     {
    //        categoryName = "Cosmetice & Îngrijire",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "Farmec",
    //                hint = "Cosmetice",
    //                startYear = 1945,
    //                about = "Farmec este cel mai mare producător de cosmetice din România și unul dintre cei mai importanți din Europa de Sud-Est."
    //            },
    //        },

    //        bonusWords = new Word[]
    //        {
    //            new Word {
    //                wordText = "Corega", 
    //                hint = "Ciocolată", 
    //                isGuess = true, 
    //                variants = new List<string>{ "Colega","Cotega", "Colcega"} 
    //            }
    //        }
    //     },
    //     #endregion

    //    #region Emisiuni & Canale TV
    //     new Category
    //     {
    //        categoryName = "Emisiuni & Canale TV",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word { wordText = "Pro TV",
    //                hint = "Emisiuni, știri, divertisment, filme",
    //                about = "„Știrile PRO TV” este cea mai urmărită emisiune de știri din România"
    //            },
    //            new Word {
    //                wordText = "Antena 1",
    //                hint = "Emisiuni, știri, divertisment, filme"
    //            },
    //            new Word {
    //                wordText = "Kiss",
    //                hint = "Muzică"
    //            },
    //            new Word {
    //                wordText = "Survivor",
    //                hint = "Reality show",
    //                startYear = 2020,
    //                about = "Survivor România este varianta românească a Survivor Turkey. Versiunea românească a fost lansată pe 18 ianuarie 2020 pe Kanal D România. Concurentul care va câștiga va primi un premiu în valoare de 250.000 lei."
    //            },               
    //            new Word {
    //                wordText = "Trinitas",
    //                hint = "Religie"
    //            },                
    //            new Word {
    //                wordText = "X Factor",
    //                hint = "Emisiune TV"
    //            },
    //            new Word {
    //                wordText = "Kanal D",
    //                hint = "Emisiuni, știri, divertisment, filme"
    //            },               
    //            new Word {
    //                wordText = "Prima TV",
    //                hint = "Emisiuni, știri, divertisment, filme"
    //            },
    //            new Word {
    //                wordText = "Minimax",
    //                hint = "Desene animate"
    //            },
    //            new Word {
    //                wordText = "Antena 3",
    //                hint = "Știri"
    //            },
    //            new Word {
    //                wordText = "Taraf",
    //                hint = "Muzică populară"
    //            },               
    //            new Word {
    //                wordText = "TVR",
    //                hint = "Emisiuni, știri, divertisment, filme"
    //            },
    //            new Word {
    //                wordText = "Digi24",
    //                hint = "Emisiuni, știri"
    //            },
    //            new Word {
    //                wordText = "iUmor",
    //                hint = "Emisiune de divertisment",
    //                startYear = 2016,
    //                about = "iUmor este o emisiune de televiziune care este difuzată de postul Antena 1. Este un program de televiziune de tip concurs reality television. Câștigătorul concursului primește un premiu de 20.000 de euro."
    //            },
    //        }
    //     },
    //    #endregion                

    //    #region Băuturi & Alimente
    //    new Category
    //     {
    //        categoryName = "Băuturi & Alimente",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {              
    //            new Word {
    //                wordText = "Timișoreana",
    //                hint = "Bere",
    //                startYear = 1718,
    //                about = "Din 2006, Timișoreana este lider pe piața berii din România."
    //            },               
    //            new Word {
    //                wordText = "Cotnari",
    //                hint = "Vin"
    //            },
    //            new Word {
    //                wordText = "Borsec",
    //                hint = "Apă"
    //            },
    //            new Word {
    //                wordText = "Zizin",
    //                hint = "Apă"
    //            },
    //            new Word {
    //                wordText = "Ciucaș",
    //                hint = "Bere"
    //            },
    //            new Word {
    //                wordText = "Murfatlar",
    //                hint = "Vinuri",
    //                startYear = 1943,
    //                about = "Compania dispune de 3.000 de hectare în zona localităților Murfatlar, Valul lui Traian, Poarta Albă și Siminoc."
    //            },
    //            new Word {
    //                wordText = "Stânceni",
    //                hint = "Apă"
    //            },
    //            new Word {
    //                wordText = "Jidvei",
    //                hint = "Vinuri",
    //                startYear = 1968,
    //                about = "Cu o suprafață  totală de peste 2.500 de hectare de viță-de-vie, acesta deține cea mai mare plantație viticolă din țară și cea mai mare podgorie cu proprietar unic din Europa."
    //            },
    //            new Word {
    //                wordText = "Fares",
    //                hint = "Ceai"
    //            },
    //            new Word {
    //                wordText = "ROM",
    //                hint = "Ciocolată",
    //                country = "Netherlands",
    //                startYear=1943
    //            },
               
    //            new Word {
    //                wordText = "Zuzu",
    //                hint = "Lactate",
    //                startYear = 2006,
    //                about = "Potrivit A.C. Nielsen, Zuzu este cel mai vândut lapte ca volum, în România, în perioada ianuarie-octombrie 2017."
    //            },
    //            new Word {
    //                wordText = "Agricola",
    //                hint = "Carne",
    //                startYear = 1992,
    //                about = "Agricola Bacău este un grup de companii din România. Grupul este unul dintre principalii producători și procesatori de carne de pasăre, cu o cotă de piață de aproximativ 10%."
    //            },
    //            new Word {
    //                wordText = "Eugenia",
    //                hint = "Biscuiți cu cremă de cacao",
    //                startYear = 1997 ,
    //                about = "Marca Eugenia a devenit substantiv comun, produsele asemănătoare nemaifiind numite „biscuiți cu cremă de cacao” ci „eugenii”."
    //            },
    //            new Word {
    //                wordText = "Râureni",
    //                hint = "Dulceață, gem",
    //                startYear = 1968
    //            },
    //            new Word {
    //                wordText = "Măgura",
    //                hint = "Dulciuri"
    //            },
    //            new Word {
    //                wordText = "Bunica",
    //                hint = "Ulei",
    //                startYear = 1999
    //            },
    //            new Word {
    //                wordText = "Băneasa",
    //                hint = "Făină "
    //            },              
    //            new Word {
    //                wordText = "Napolact",
    //                hint = "Lactate",
    //                startYear = 1905,
    //                about = "Napolact este un brand al companiei olandeze FrieslandCampina, unul dintre cei mai mari producători de lactate din lume. Brandul este folosit doar în România, unde compania deținea în 2015 două fabrici în județul Cluj și una în Târgu Mureș."
    //            },
    //            new Word {
    //                wordText = "RoStar",
    //                hint = "Biscuiți",
    //                startYear = 1996,
    //                about = "RoStar este o companie producătoare de biscuiți din România cu o capacitate de producție de 50 tone pe zi și 410 angajați."
    //            },
    //            new Word {
    //                wordText = "Olympus",
    //                hint = "Lactate",
    //                country = "Greece",
    //                about = "Olympus Dairy este o companie producătoare de lactate din Grecia. Este prezentă în 34 de țări și are cinci unități de producție, 3 în Grecia și câte una în Bulgaria și România."
    //            },
    //            new Word {
    //                wordText = "Albalact",
    //                hint = "Lactate",
    //                startYear = 1971,
    //                about = "Albalact este o companie românească înființată în 1971 sub denumirea de Întreprinderea de Industrializare a Laptelui Alba."
    //            },
    //            new Word {
    //                wordText = "Covalact",
    //                hint = "Lactate",
    //                startYear = 1969,
    //                about = "Covalact este o companie producătoare de produse lactate din România."
    //            },
    //            new Word {
    //                wordText = "Vel Pitar",
    //                hint = "Panificație",
    //                startYear = 1990,
    //                about = "Vel Pitar este un grup de companii din România, cu activitate în domeniul morăritului și panificației. Grupul deține 12 fabrici de pâine în zece județe din țară și în București, având peste 170 de magazine proprii (martie 2009)."
    //            }
    //        },
    //     },
    //     #endregion

    //    #region Companii & Servicii
    //     new Category
    //     {
    //        categoryName = "Companii & Servicii",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            //new Word { wordText = "poșta română", hint = "Apă",  },    
    //            //new Word { wordText = "Regina Maria", hint = "Rețea privată de sănătate", foundedYear=1995,
    //               // about="Numele companiei a venit de la Maria Alexandra Victoria, Prințesa de Edinburgh, nepoata Reginei Victoria a Angliei care în 1914 devine Regina Maria a României. În timpul Primului Război Mondial ea a dedicat cu generozitate bolnavilor și muribunzilor timp și energie din plin." },

    //            new Word {
    //                wordText = "ARO",
    //                hint = "Automobile",
    //                startYear = 1957,
    //                endYear = 2002,
    //                about = "ARO a produs peste 380.000 de vehicule, dintre care două treimi au fost exportate în peste 110 țări"
    //            },
    //            new Word {
    //                wordText = "Pegas",
    //                hint = "Biciclete",
    //                startYear = 1972,
    //                about = "Unul dintre sloganurile fabricii este luat dintr-o scrisoare a scriitorului francez Gustave Flaubert: „Pegas mai des merge decât galopează: tot talentul este să știi să-l strunești ca să meargă cu viteza dorită."
    //            },
    //            new Word {
    //                wordText = "CFR",
    //                hint = "Infrastructură feroviară",
    //                startYear = 1998
    //            },
    //            new Word {
    //                wordText = "Allview",
    //                hint = "Smartphone-uri, electronice",
    //                startYear = 2002,
    //                about = "Allview este un brand deținut de compania românească Visual Fan care comercializează smartphone-uri. Activează din 2002 în zona de electronice și fondatorul este Lucian Peticilă."
    //            },
    //            new Word {
    //                wordText = "SuperBet",
    //                hint = "Casă de pariuri",
    //                startYear = 2008,
    //                about = "Superbet a fost fondat în 2008, în București. Prima agenție Superbet este deschisă în Oradea. Compania deschide agenția 500 în anul 2015, iar în august 2017 pe cea cu numărul 600."
    //            },

    //            new Word {
    //                wordText = "ING",
    //                hint = "Servicii bancare",
    //                startYear = 1994,
    //                about = "ING Bank România este parte a ING Group, instituție financiară internațională globală, care oferă servicii bancare unui număr de peste 34 de milioane de clienți individuali, companii sau instituții din peste 40 de țări."
    //            },

    //            new Word {
    //                wordText = "BRD",
    //                hint = "Servicii bancare",
    //                startYear = 1923,
    //                about = "BRD - Groupe Société Générale (Banca Română pentru Dezvoltare), este o bancă românească deținută de grupul financiar francez Société Générale. În 2013, ea a fost a doua bancă din România, după Banca Comercială Română (BCR)."
    //            },
    //            new Word {
    //                wordText = "BCR",
    //                hint = "Servicii bancare",
    //                startYear = 1990
    //            },
    //            new Word {
    //                wordText = "Rompetrol",
    //                hint = "Benzinărie",
    //                startYear = 1974
    //            },
    //            new Word {
    //                wordText = "Dacia",
    //                hint = "Autovehicule",
    //                startYear = 1966
    //            },
    //            new Word {
    //                wordText = "Digi",
    //                hint = "Operator de telecomunicații mobile",
    //                startYear = 1994
    //            },
    //            new Word {
    //                wordText = "Dero",
    //                hint = "Detergent de rufe",
    //                startYear = 1966,
    //                about = "Numele Dero creat in 1966 este o abreviere pentru Detergenti Romania"
    //            },
    //            new Word {
    //                wordText = "Petrom",
    //                hint = "Benzinărie",
    //                startYear = 1991
    //            },
    //            new Word {
    //                wordText = "Arctic",
    //                hint = "Electrocasnice",
    //                startYear = 1968,
    //                about = "Arctic este lider pe piața de produse electrocasnice din România, cu o cotă de piață de 35%."
    //            },
    //            new Word {
    //                wordText = "CEC",
    //                hint = "Servicii bancare",
    //                startYear = 1864,
    //                about = "Casa de Economii și Consemnațiuni este o instituție bancară din România, deținută de stat. În august 2009, banca avea 2,7 milioane clienți."
    //            },
    //            new Word {
    //                wordText = "Cargus",
    //                hint = "Curierat",
    //                about = "Urgent Cargus este o companie de curierat rapid din România, prima de acest tip din România. Compania a fost cumpărată de DHL în 2008 pentru o sumă estimată la 50 milioane Euro."
    //            },
    //            new Word {
    //                wordText = "DPD",
    //                hint = "Curierat",
    //                startYear = 1999,
    //                about = "DPD România este o companie de curierat din România. Compania este prezentă și pe piața din Bulgaria de la 1 iulie 2007. În anul 2013 livra zilnic circa 15.000 de colete."
    //            },
    //            new Word {
    //                wordText = "Țiriac Auto",
    //                hint = "Dealer auto",
    //                about = "ȚiriacAuto este divizia auto a grupului Țiriac Holding și este un important importator auto din România. ȚiriacAuto, controlează 12 dealeri din București, Brașov, Cluj, Timișoara, Iași și Oradea. Cifra de afaceri în 2008: 1,2 miliarde euro."
    //            },
    //            new Word {
    //                wordText = "Fan Courier",
    //                hint = "Curierat",
    //                startYear = 1998,
    //                about = "FAN Courier Express este o companie de curierat din România, cu sediul în București și expediază cu propria flotă de 1.500 mașini (sistem „door to door”) plicuri și colete în țară."
    //            },
    //            new Word {
    //                wordText = "Sameday",
    //                hint = "Curierat",
    //                startYear = 2007
    //            },
    //            new Word {
    //                wordText = "Euroins",
    //                hint = "Asigurări auto",
    //                startYear = 1994,
    //                about = "Euroins România este o companie de asigurări din România. Compania a avut numele de Asitrans până în 2008."
    //            },
    //            new Word {
    //                wordText = "Tarom",
    //                hint = "Servicii aeriene"
    //            },
    //        },
    //     },
    //     #endregion
                
    //    #region Politică & Sport
    //    new Category
    //     {
    //        categoryName = "Politică & Sport",
    //        words = new Word[]
    //        {
    //            new Word { wordText = "Steaua", hint = "Echipă de fotbal din București" },
    //            new Word { wordText = "Voluntari", hint = "Echipă de fotbal" },
    //            new Word { wordText = "Botoșani", hint = "Echipă de fotbal" },
    //            new Word { wordText = "Rapid", hint = "Echipă de fotbal din București" },
    //            new Word { wordText = "Dinamo", hint = "Echipă de fotbal din București" },
    //            new Word { wordText = "Astra Giurgiu", hint = "Echipă de fotbal" },
    //            new Word { wordText = "Viitorul", hint = "Echipă de fotbal" },

    //            new Word { wordText = "PSD", hint = "Partid de centru-stânga ", about = "Partidul Social Democrat", startYear = 2001 },
    //            new Word { wordText = "UDMR", hint = "Partid de centru-dreapta", about = "Uniunea Democrată Maghiară din România", startYear = 1989 },
    //            new Word { wordText = "PMP", hint = "Partid de centru-dreapta", about = "Partidul Mișcarea Populară", startYear = 2014 },
    //            new Word { wordText = "PRO", hint = "Partid de centru", about = "PRO România Social-Liberal", startYear = 2020 },
    //            new Word { wordText = "PNL", hint = "Partid de centru-dreapta", about = "Partidul Național Liberal", startYear = 1875 },
    //            new Word { wordText = "USR", hint = "Partid de centru-dreapta", about = "Uniunea Salvați România", startYear = 2019 },
    //            new Word { wordText = "AUR", hint = "Partid de centru-dreapta", about = "Alianța pentru Unirea Românilor", startYear = 2019 },
    //            new Word { wordText = "PV", hint = "Partid de centru", about = "Partidul Verde", startYear = 2005 },
    //            new Word { wordText = "PRM", hint = "Partid de centru-stânga", about = "Partidul România Mare", startYear = 1991 }
    //        }
    //     },
    //    #endregion
    //};

    //public static Category[] categoriesEN = new Category[]
    //{
    //    #region Magazine & Restaurante
    //    new Category
    //     {
    //        categoryName = "Magazine & Restaurante",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "Vivo",
    //                hint = "Mall"
    //            },
    //            new Word {
    //                wordText = "Afi",
    //                hint = "Mall"
    //            },
    //            new Word {
    //                wordText = "Băneasa",
    //                hint = "Mall"
    //            },
    //            new Word {
    //                wordText = "Auchan",
    //                hint = "Supermarket",
    //                startYear = 1961,
    //                country = Countries.France,
    //                about = "Auchan este un retailer multinational francez, cu sediul central la Lille, Franța. Auchan a intrat în România printr-un parteneriat cu investitori străini și români, care au adus și condus rețeaua Cora. "
    //            },
    //            new Word {
    //                wordText = "Lidl",
    //                hint = "Supermarket",
    //                startYear = 1930,
    //                country = Countries.Germany,
    //                about = "Lidl este un lanț de magazine de tip discount fondat în Germania. Lidl deține peste 10.000 de magazine la nivel internațional. LIDL este un diminutiv de alintare al prenumelui german Ludwig."
    //            },
    //            new Word {
    //                wordText = "Cărturești",
    //                hint = "Librărie",
    //                startYear = 2000,
    //                about = "Cărturești este o companie care deține o rețea de 12 librării în România. Cărtureşti a primit premiul Superbrands Romania, pentru performanţe excepţionale în branding, în anii 2008, 2009 şi 2013"
    //            },
    //            new Word {
    //                wordText = "CCC",
    //                hint = "Îcălțăminte și accesorii",
    //                startYear = 1999,
    //                country = Countries.Poland,
    //                about = "CCC este o rețea de retail de încălțăminte, deținută de firma NG2 din Polonia. Compania a fost fondată de Dariusz Milek, absolvent al unei școli de minerit, care în 1991, vindea bunuri într-o piață în aer liber din orașul Lubin."
    //            },
    //            new Word {
    //                wordText = "IKEA",
    //                hint = "Mobilă",
    //                startYear = 1983,
    //                country = Countries.Netherlands,
    //                about = "IKEA este o companie privată care comercializează mobilier casnic. Compania a fost fondată în Suedia, dar este deținută de către o fundație olandeză."
    //            },
    //            new Word
    //            {
    //                wordText = "Carrefour",
    //                hint = "Hipermarket",
    //                startYear = 1958,
    //                country = Countries.France,
    //                about = "Carrefour este o companie multinațională franceză, fiind unul din cei mai mari retaileri din lume cu peste 12.300 de magazine în anul 2018. Carrefour este un retailer important în România cu afaceri de 10 miliarde de lei în 2018."
    //            },
    //            new Word {
    //                wordText = "Catena",
    //                hint = "Farmacie",
    //                startYear = 1999,
    //                about = "Catena este cel mai mare lanț de farmacii din România, deținut de grupul Fildas."
    //            },
    //            new Word {
    //                wordText = "Tucano",
    //                hint = "Cafenea",
    //                startYear = 2010,
    //            },
    //            new Word {
    //                wordText = "Cora",
    //                hint = "Supermarket",
    //                startYear = 1969,
    //                country = Countries.Belgium,
    //                about = "În România există 11 hipermarket-uri Cora. Primul hipermarket Cora din România a fost deschis la 1 octombrie 2003 în urma unei investiții de 50 de milioane de euro."
    //            },
    //            new Word {
    //                wordText = "Profi",
    //                hint = "Supermarket",
    //                startYear = 1979,
    //                about = "Profi este un lanț de supermarketuri și magazine de proximitate în România, deținut de către fondul de investiții Mid Europa Partners."
    //            },
    //            new Word {
    //                wordText = "Flanco",
    //                hint = "Electronice, electrocasnice, IT&C",
    //                startYear = 1990,
    //                about="Flanco este o rețea de magazine de produse electronice, electrocasnice și IT&C din România. Compania a fost înființată de omul de afaceri Florin Andronescu, iar numele Flanco vine de la Florin Andronescu Company."
    //            },
    //            new Word {
    //                wordText = "Mega Image",
    //                hint = "Supermarket",
    //                startYear = 1995,
    //                about = "Mega Image este un lanț de supermarketuri si magazine de proximitate din România, fondat în București în 1995. În anul 2015 existau 704 magazine în țară."
    //            },
    //            new Word {
    //                wordText = "Dedeman",
    //                hint = "Magazin de scule",
    //                startYear = 1992,
    //                about = "Dedeman este o companie din orașul Bacău, România care se ocupă cu vânzarea de materiale de construcții și amenajări interioare."
    //            },
    //            new Word {
    //                wordText = "Jumbo",
    //                hint = "Magazin grecesc",
    //                startYear = 1986,
    //                country = Countries.Greece,
    //                about = "Jumbo este un retailer grec de jucării și decorațiuni interioare. Primul magazin din România a fost deschis in 2013 în locul fostului magazin Real din Timișoara."
    //            },
    //            new Word {
    //                wordText = "Zara",
    //                hint = "Îmbrăcăminte și accesorii",
    //                startYear = 1975,
    //                country = Countries.Spain,
    //                about = "Zara este o companie de vânzare cu amănuntul fondată de Amancio Ortega și Rosalía Mera. Se pretinde că Zara are nevoie de doar două săptămâni pentru a dezvolta un produs și lansează în jur de 10.000 de modele noi în fiecare an."},
    //            new Word {
    //                wordText = "Kaufland",
    //                hint = "Supermarket",
    //                startYear = 1984,
    //                country = Countries.Germany,
    //                about = "Kaufland este un lanț de hipermarketuri din Germania, parte a grupului Schwarz, care deține și retailerul de discount Lidl. Kaufland este prezent în România din anul 2005."
    //            },
    //            new Word {
    //                wordText = "LaDoiPași",
    //                hint = "Supermarket",
    //                startYear = 2012,
    //                about = "La Doi Pași este o franciză de magazine de proximitate lansată de compania Metro. Brandul reunește peste 1000 de magazine, deținute de mici comercianți independenți, majoritatea în orașe mici și comune."
    //            },
    //            new Word {
    //                wordText = "Metro",
    //                hint = "Magazine cash & carry",
    //                startYear = 1964,
    //                country = Countries.Germany,
    //                about = "Metro operează magazine cash & carry, pe bază de card membru doar persoanelor juridice. În anul 1996 compania a deschis în parteneriat cu omul de afaceri Ion Țiriac, primul magazin Metro în Otopeni. Acesta a fost primul magazin mare modern din România."
    //            },
    //            new Word {
    //                wordText = "Mobexpert",
    //                hint = "magazin de mobilă",
    //                startYear = 1993,
    //                about = "Grupul Mobexpert este liderul pe piața de mobilier din România. Mobexpert se clasează între primele douăsprezece întreprinderi europene din industria mobilei."
    //            },
    //            new Word {
    //                wordText = "Penny",
    //                hint = "Supermarket",
    //                startYear = 1973,
    //                country = Countries.Germany,
    //                about = "Penny este un lanț de supermarketuri german. În 2019, deținea 240 de supermarketuri in România."
    //            },
    //            new Word {
    //                wordText = "Selgros",
    //                hint = "Magazine cash & carry",
    //                startYear = 1959,
    //                country = Countries.Switzerland,
    //                about = "Selgros deține 91 de magazine, din care 38 în Germania, 23 în România, 19 în Polonia și 11 în Rusia. Compania a intrat pe piața din România în anul 2001 prin deschiderea primului magazin în Brașov, unde se află și sediul administrației centrale."
    //            },
    //            new Word {
    //                wordText = "Sephora",
    //                hint = "Parfumuri și produse de înfrumusețare",
    //                startYear = 1970,
    //                country = Countries.France,
    //                about = "Sephora este un celebru lanț de magazine cu parfumuri și produse de înfrumusețare, înființat în 1969, de Dominique Mandonnaund, în Franța. Compania este prezentă și în România, având 19 magazine și 250 de angajați în anul 2010."
    //            },
    //            new Word {
    //                wordText = "Pepco",
    //                hint = "Magazin",
    //                startYear = 1999,
    //                country = Countries.Poland,
    //                about = "Pepco este o rețea europeană de magazine de articole de îmbrăcăminte și industriale cu prețuri reduse."
    //            },
    //            new Word {
    //                wordText = "H&M",
    //                hint = "Îmbrăcăminte și accesorii",
    //                startYear = 1947,
    //                country = Countries.Sweden,
    //                about = "H & M (forma scurtă pentru Hennes & Mauritz) este o companie suedeză de îmbrăcăminte din Stockholm. Compania a deschis primul magazin în România pe 25 martie 2011, în centrul comercial AFI Palace Cotroceni."
    //            },
    //            new Word {
    //                wordText = "Decathlon",
    //                hint = "Accesorii sportive",
    //                startYear = 1976,
    //                country = Countries.France,
    //                about = "Decathlon este cel mai mare vânzător de produse sportive din lume. Brandul Decathlon este deținut de familia miliardarilor francezi Mulliez, care mai deține hipermarketurile Auchan, magazinele Kiabi și retailerul de bricolaj Leroy Merlin."
    //            },
    //            new Word {
    //                wordText = "Filicori",
    //                hint = "Cafenea",
    //                startYear = 1919,
    //            },
    //            new Word {
    //                wordText = "5 To Go",
    //                hint = "Cafenea",
    //                about = "5 to go este cel mai mare lanț de cafenele din Europa de Est și cea mai accesată franciză din România. Brandul 100% românesc e prezent în peste 140 de locații la momentul actual, în București și în alte 17 orașe din țară."
    //            },
    //            new Word {
    //                wordText = "McDonald's",
    //                hint = "Fast Food",
    //                startYear = 1955,
    //                country = Countries.USA,
    //                about = "McDonald's este prezent în România din iunie 1995, când a fost deschis primul restaurant la parterul Complexului Comercial Unirea."
    //            }
    //        },

    //        bonusWords = new Word[]
    //        {
    //            new Word {
    //                wordText = "Annabella",
    //                hint = "Supermarket",
    //                startYear = 1994,
    //                isGuess = true,
    //                variants = new List<string>{ "Alabella", "Balabella", "Sanabella"},
    //                about = "Sub numele Annabella funcţionează azi nu mai puţin de 90 de magazine răspândite în tot judeţul Vâlcea şi nu numai. Annabella a dedicat segmentului alimentar, o proporție de 75% din spațiul său, restul fiind ocupat de produse non alimentare." }
    //        }
    //     },
    //    #endregion

    //    #region Aplicații & Site-uri
    //    new Category
    //     {
    //        categoryName = "Aplicații & Site-uri",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "Autovit",
    //                hint = "Vânzări auto second-hand",
    //                startYear = 2000,
    //                about = "Autovit.ro este cel mai mare site de vânzări de mașini second-hand din România."
    //            },
    //            new Word {
    //                wordText = "CEL.ro",
    //                hint = "Tehnologie",
    //                startYear = 2005,
    //                about = "CEL.ro este un magazin online de IT&C cu sediul în București, administrat în prezent de compania Corsar Online SRL cu capital 100% românesc."
    //            },
    //            new Word {
    //                wordText = "Glovo",
    //                hint = "Livrare de mâncare",
    //                startYear = 2015,
    //                country = Countries.Spain,
    //                about = "Glovo (O scriere greșită a lui Globo, adică balon în spaniolă) este un start up spaniol fondat în Barcelona. Este un serviciu de curierat la cerere care achiziționează, ridică și livrează produse comandate prin aplicația sa mobilă."
    //            },
    //            new Word {
    //                wordText = "Revolut",
    //                hint = "Companie financiară",
    //                startYear = 2015,
    //                country = Countries.UK,
    //                about = "Revolut Ltd este o companie financiară care oferă conturi bancare "
    //            },
    //            new Word {
    //                wordText = "Uber",
    //                hint = "Rideshareing",
    //                startYear = 2009,
    //                country = Countries.USA,
    //                about = "Uber este o companie americană care a dezvoltat o aplicație pentru tablete și smartphone-uri care le pemite clienților să comande limuzine cu șofer sau taxiuri."
    //            },
    //            new Word {
    //                wordText = "Trilulilu",
    //                hint = "Amuzament",
    //                startYear = 2007,
    //                about = "Trilulilu a fost site web românesc care dedicat pentru încărcarea fișierelor video și fișierelor de tip audio și imagini. În august 2010, Trilulilu era al doilea site din România ca număr de accesări (după Hi5)."
    //            },
    //            new Word {
    //                wordText = "Libertatea",
    //                hint = "Ziar",
    //                startYear = 1989,
    //                about = "Libertatea este un ziar din România, care publică articole din domenii precum social, știri, entertainment și lifestyle. A fost fondat în 22 decembrie 1989, devenind astfel ”primul ziar independent al Revoluției Române din 1989"
    //            },
    //            new Word {
    //                wordText = "OLX",
    //                hint = "Secondhand",
    //                startYear = 2006,
    //                country = Countries.USA,
    //                about = "OLX este un website de vânzări în piața online fondat în anul 2006, care operează în 45 de țări."
    //            },
    //            new Word {
    //                wordText = "Mercador.ro",
    //                hint = "Secondhand",
    //                startYear = 2006,
    //                about = "In 2014, Mercador.ro, isi schimba numele in OLX.ro printr-un proces de rebranding la nivelul grupului Naspers."
    //            },
    //            new Word {
    //                wordText = "Bolt",
    //                hint = "Rideshareing",
    //                country = Countries.Estonia,
    //                about = "Bolt operează în peste 200 de orașe din 40 de țări din Europa, Africa, Asia de Vest și America Latină."
    //            },
    //            new Word {
    //                wordText = "Telegram",
    //                hint = "Mesagerie"
    //            },
    //            new Word {
    //                wordText = "Emag",
    //                hint = "Tehnologie"
    //            },
    //            new Word {
    //                wordText = "Yahoo!",
    //                hint = ""
    //            },
    //            new Word {
    //                wordText = "Trivago",
    //                hint = "Hotel?"
    //            },
    //            new Word {
    //                wordText = "Elefant",
    //                hint = "Magazin online",

    //            },
    //            new Word {
    //                wordText = "Publi24",
    //                hint = "Secondhand"
    //            },
    //            new Word {
    //                wordText = "Answer",
    //                hint = "Haine și încălțăminte",
    //                startYear = 2010,
    //                country = Countries.Poland
    //            },
    //            new Word {
    //                wordText = "LaJumate.ro",
    //                hint = ""
    //            },
    //            new Word {
    //                wordText = "Foodpanda",
    //                hint = "Livrare de mâncare",
    //                about = "Foodpanda este un serviciu pentru comenzi de mâncare prezentă pe piața românească din 2013. Este cea mai mare platformă de profil din România, colaborând cu peste 500 de restaurante din peste 10 orașe din țară.",
    //                country = Countries.Germany,
    //                startYear = 2012},
    //            new Word {
    //                wordText = "eJobs",
    //                hint = "Locuri de muncă"
    //            },
    //            new Word {
    //                wordText = "YOXO",
    //                hint = "Telecomunicații mobile"
    //            },
    //            new Word {
    //                wordText = "Tazz",
    //                hint = "Livrare de mâncare"
    //            },
    //            new Word {
    //                wordText = "ABOUT YOU",
    //                hint = "Îmbrăcăminte și accesorii"
    //            },
    //            new Word {
    //                wordText = "HotNews",
    //                hint = "Știri"
    //            },
    //            new Word {
    //                wordText = "Softpedia",
    //                hint = "Forum"
    //            },
    //            new Word {
    //                wordText = "Netflix",
    //                hint = "Streaming video",
    //                startYear = 1997,
    //                country = Countries.USA
    //            },
    //            new Word {
    //                wordText = "AntenaPlay",
    //                hint = "",
    //            },
    //            new Word {
    //                wordText = "Badoo",
    //                hint = "Matrimoniale",
    //            },
    //            new Word {
    //                wordText = "Playtech",
    //                hint = "Știri despre tehnologie"
    //            },
    //            new Word {
    //                wordText = "Sport.ro",
    //                hint = "Știri sportive"
    //            },
    //            new Word {
    //                wordText = "GSP.ro",
    //                hint = "Știri sportive"
    //            },
    //            new Word {
    //                wordText = "Mobilissimo",
    //                hint = "Știri despre tehnologie"
    //            },
    //            new Word {
    //                wordText = "Voyo",
    //                hint = ""
    //            },
    //        },

    //        bonusWords = new Word[]
    //        {
    //            new Word {
    //                wordText = "BlaBlaCar",
    //                hint = "Rideshareing",
    //                isGuess = true,
    //                variants = new List<string>{ "VlaVlaCar", "LaLaCar", "Vruum"}
    //            }
    //        }
    //     },
    //    #endregion

    //    #region YouTube & Muzică
    //    new Category
    //     {
    //        categoryName = "YouTube & Muzică",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "BUG Mafia",
    //                hint = "Trupă de muzică",
    //                startYear = 1993,
    //                about = "B.U.G. Mafia este o trupă de hip-hop din România fondată în anul 1993. Actualii componenți sunt Tataee, Caddy și Uzzi."
    //            },
    //            new Word {
    //                wordText = "Neversea",
    //                hint = "Festival de muzică",
    //                startYear = 2017,
    //                about = "Neversea Festival este cel mai mare festival de muzică care are loc pe o plajă din România. Acesta se desfășoară în fiecare an pe Neversea Beach din Constanța, în apropierea plajei Modern."
    //            },
    //            new Word {
    //                wordText = "Untold",
    //                hint = "Festival de muzică",
    //                startYear = 2015,
    //                about = "Untold Festival este cel mai mare festival de muzică din România. Acesta se desfășoară în fiecare an pe Cluj Arena în orașul Cluj Napoca."
    //            },
    //            new Word {
    //               wordText = "Romexpo",
    //               hint = "Centru expozițional",
    //               startYear = 1962,
    //               about = "ROMEXPO, cel mai important centru expozițional din București și din România, reprezintă punctul de referință pentru toate evenimentele românești."
    //            },
    //            new Word { wordText = "Nek Music", hint = "Muzică", },
    //            new Word { wordText = "Roton", hint = "Muzică" },
    //            new Word { wordText = "Cat Music", hint = "Muzică" },
    //            new Word { wordText = "Trapanele", hint = "Muzică" },

    //            new Word { wordText = "Bratu Art", hint = "Desen" },

    //            new Word { wordText = "iRaphahell", hint = "Gaming" },
    //            new Word { wordText = "iHatePink", hint = "Gaming" },
    //            new Word { wordText = "Jamila", hint = "Gaming" },
    //            new Word { wordText = "MaxINFINITE", hint = "Gaming" },
    //            new Word { wordText = "Gannicus96", hint = "Gaming" },
    //        }
    //     },
    //     #endregion
              
    //    #region Cosmetice & Îngrijire
    //     new Category
    //     {
    //        categoryName = "Cosmetice & Îngrijire",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "Always",
    //                hint = "Produse de igienă feminină",
    //                startYear = 1983,
    //                country = Countries.USA
    //            },
    //            new Word {
    //                wordText = "L'Oreal",
    //                hint = "Cosmetică",
    //                country = Countries.France
    //            },
    //            new Word {
    //                wordText = "Avon",
    //                hint = "Cosmetică, parfumuri",
    //                startYear = 1886,
    //                country = "Grand Britan"
    //            },
    //            new Word {
    //                wordText = "Colgate",
    //                hint = "Lactate",
    //                startYear=1954,
    //                country = Countries.Germany
    //            },
    //            new Word {
    //                wordText = "Dove",
    //                hint = "Săpun, gel de duș",
    //                startYear = 1955,
    //                country = Countries.USA
    //            },
    //            new Word {
    //                wordText = "Farmec",
    //                hint = "Cosmetice",
    //                startYear = 1945,
    //                about = "Farmec este cel mai mare producător de cosmetice din România și unul dintre cei mai importanți din Europa de Sud-Est."
    //            },
    //            new Word {
    //                wordText = "Garnier",
    //                hint = "Cosmetice",
    //                startYear = 1904,
    //                country = Countries.France
    //            },
    //            new Word {
    //                wordText = "Protex",
    //                hint = "Săpun",
    //                startYear = 1985,
    //                country = Countries.USA
    //            },
    //            new Word {
    //                wordText = "Fa",
    //                hint = "Lactate",
    //                startYear = 1954,
    //                country = Countries.Germany
    //            },
    //            new Word {
    //                wordText = "Gillette",
    //                hint = "Ingrijire personală",
    //                startYear = 1901,
    //                country = Countries.USA
    //            },
    //            new Word {
    //                wordText = "Blend-a-med",
    //                hint = "",
    //                startYear = 1967,
    //                country = Countries.Switzerland
    //            },
    //            new Word {
    //                wordText = "Oriflame",
    //                hint = "",
    //                startYear = 1967,
    //                country = Countries.Switzerland
    //            }
    //        },

    //        bonusWords = new Word[]
    //        {
    //            new Word { wordText = "Corega", hint = "Ciocolată", isGuess = true, variants = new List<string>{ "Colega","Cotega", "Colcega"},   }
    //        }
    //     },
    //     #endregion

    //    #region Emisiuni & Canale TV
    //     new Category
    //     {
    //        categoryName = "Emisiuni & Canale TV",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word { wordText = "Pro TV",
    //                hint = "Emisiuni, știri, divertisment, filme",
    //                about = "„Știrile PRO TV” este cea mai urmărită emisiune de știri din România"
    //            },
    //            new Word {
    //                wordText = "Antena 1",
    //                hint = "Emisiuni, știri, divertisment, filme"
    //            },
    //            new Word {
    //                wordText = "Kiss",
    //                hint = "Muzică"
    //            },
    //            new Word {
    //                wordText = "Survivor",
    //                hint = "Reality show",
    //                startYear = 2020,
    //                about = "Survivor România este varianta românească a Survivor Turkey. Versiunea românească a fost lansată pe 18 ianuarie 2020 pe Kanal D România. Concurentul care va câștiga va primi un premiu în valoare de 250.000 lei."
    //            },
    //            new Word {
    //                wordText = "Discovery",
    //                hint = "Documentare"
    //            },
    //            new Word {
    //                wordText = "HBO",
    //                hint = "Filme"
    //            },
    //            new Word {
    //                wordText = "Trinitas",
    //                hint = "Religie"
    //            },
    //            new Word {
    //                wordText = "History",
    //                hint = "Documentare"
    //            },
    //            new Word {
    //                wordText = "X Factor",
    //                hint = "Emisiune TV"
    //            },
    //            new Word {
    //                wordText = "Kanal D",
    //                hint = "Emisiuni, știri, divertisment, filme"
    //            },
    //            new Word {
    //                wordText = "MTV",
    //                hint = "Muzică"
    //            },
    //            new Word {
    //                wordText = "Prima TV",
    //                hint = "Emisiuni, știri, divertisment, filme"
    //            },
    //            new Word {
    //                wordText = "Minimax",
    //                hint = "Desene animate"
    //            },
    //            new Word {
    //                wordText = "Antena 3",
    //                hint = "Știri"
    //            },
    //            new Word {
    //                wordText = "Taraf",
    //                hint = "Muzică populară"
    //            },
    //            new Word {
    //                wordText = "TV Paprika",
    //                hint = "Culinar"
    //            },
    //            new Word {
    //                wordText = "TVR",
    //                hint = "Emisiuni, știri, divertisment, filme"
    //            },
    //            new Word {
    //                wordText = "Digi24",
    //                hint = "Emisiuni, știri"
    //            },
    //            new Word {
    //                wordText = "iUmor",
    //                hint = "Emisiune de divertisment",
    //                startYear = 2016,
    //                about = "iUmor este o emisiune de televiziune care este difuzată de postul Antena 1. Este un program de televiziune de tip concurs reality television. Câștigătorul concursului primește un premiu de 20.000 de euro."
    //            },
    //        }
    //     },
    //    #endregion                

    //    #region Băuturi & Alimente
    //    new Category
    //     {
    //        categoryName = "Băuturi & Alimente",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            new Word {
    //                wordText = "Prigat",
    //                hint = "Suc",
    //                country = "Israel",
    //                startYear = 1940,
    //            },
    //            new Word {
    //                wordText = "Timișoreana",
    //                hint = "Bere",
    //                startYear = 1718,
    //                about = "Din 2006, Timișoreana este lider pe piața berii din România."
    //            },
    //            new Word {
    //                wordText = "Pepsi",
    //                hint = "Băuturi răcoritoare",
    //                startYear = 1898,
    //                about = "În 1898 purta numele de Brad’s Drink, după 1961 Pepsi-Cola, iar acum doar Pepsi."
    //            },
    //            new Word {
    //                wordText = "Cotnari",
    //                hint = "Vin"
    //            },
    //            new Word {
    //                wordText = "Borsec",
    //                hint = "Apă"
    //            },
    //            new Word {
    //                wordText = "Zizin",
    //                hint = "Apă"
    //            },
    //            new Word {
    //                wordText = "Ciucaș",
    //                hint = "Bere"
    //            },
    //            new Word {
    //                wordText = "Murfatlar",
    //                hint = "Vinuri",
    //                startYear = 1943,
    //                about = "Compania dispune de 3.000 de hectare în zona localităților Murfatlar, Valul lui Traian, Poarta Albă și Siminoc."
    //            },
    //            new Word {
    //                wordText = "Stânceni",
    //                hint = "Apă"
    //            },
    //            new Word {
    //                wordText = "Jidvei",
    //                hint = "Vinuri",
    //                startYear = 1968,
    //                about = "Cu o suprafață  totală de peste 2.500 de hectare de viță-de-vie, acesta deține cea mai mare plantație viticolă din țară și cea mai mare podgorie cu proprietar unic din Europa."
    //            },
    //            new Word {
    //                wordText = "Fares",
    //                hint = "Ceai"
    //            },

    //            new Word {
    //                wordText = "ROM",
    //                hint = "Ciocolată",
    //                country = "Netherlands",
    //                startYear=1943
    //            },
    //            new Word {
    //                wordText = "Nutella",
    //                hint = "Cremă de ciocolată",
    //                country = Countries.Italy,
    //                startYear = 1963,
    //                about = "Nutella este o cremă italiană de ciocolată făcută de către Ferrero."
    //            },
    //            new Word {
    //                wordText = "Oreo",
    //                hint = "Biscuiți de ciocolată ",
    //                country = Countries.USA,
    //                startYear = 1912,
    //                about = "Oreo a devenit cea mai vândută marcă de biscuiți din Statele Unite. Se estimează că de la începuturile producției din 1912 peste 450 de miliarde de Oreo au fost produși la nivel mondial."
    //            },
    //            new Word {
    //                wordText = "Zuzu",
    //                hint = "Lactate",
    //                startYear = 2006,
    //                about = "Potrivit A.C. Nielsen, Zuzu este cel mai vândut lapte ca volum, în România, în perioada ianuarie-octombrie 2017."
    //            },
    //            new Word {
    //                wordText = "Agricola",
    //                hint = "Carne",
    //                startYear = 1992,
    //                about = "Agricola Bacău este un grup de companii din România. Grupul este unul dintre principalii producători și procesatori de carne de pasăre, cu o cotă de piață de aproximativ 10%."
    //            },
    //            new Word {
    //                wordText = "Eugenia",
    //                hint = "Biscuiți cu cremă de cacao",
    //                startYear = 1997 ,
    //                about = "Marca Eugenia a devenit substantiv comun, produsele asemănătoare nemaifiind numite „biscuiți cu cremă de cacao” ci „eugenii”."
    //            },
    //            new Word {
    //                wordText = "Râureni",
    //                hint = "Dulceață, gem",
    //                startYear = 1968
    //            },
    //            new Word {
    //                wordText = "Nutline",
    //                hint = "Semințe",
    //                startYear = 1996,
    //                country = Countries.Germany,
    //                about = "În 1996 Nutline a fost primul brand care a lansat semințele ambalate."
    //            },
    //            new Word {
    //                wordText = "Caroli", hint = "Mezeluri",  },
    //            new Word {
    //                wordText = "Lays",
    //                hint = "Chipsuri",
    //                startYear=1950,
    //                country = Countries.USA,
    //                about = "Lay's aparține companiei PepsiCo, care avea numele de Frito-Lay în 1965. În România, Lay's este cel mai vândut și cea mai cumpărată firmă de chips-uri. Lay's și-a cumpărat propriul teren pentru a crește cartofi pentru chips-uri în 2008."
    //            },
    //            new Word {
    //                wordText = "Chio",
    //                hint = "Chipsuri",
    //                startYear = 1995,
    //                country = Countries.Germany,
    //                about = "Brandul Chio este deținut de compania Intersnack care a demarat producția în România în anul 2003, la Brașov, iar în 2009 a mutat fabrica la Ghimbav."
    //            },
    //            new Word {
    //                wordText = "Milka",
    //                hint = "Ciocolată",
    //                country = Countries.Switzerland,
    //                startYear = 1825,
    //                about = "Ciocolata Milka este produsă într-o serie de locații, inclusiv Brașov, România."
    //            },
    //            new Word {
    //                wordText = "Măgura",
    //                hint = "Dulciuri"
    //            },
    //            new Word {
    //                wordText = "Bunica",
    //                hint = "Ulei",
    //                startYear = 1999
    //            },
    //            new Word {
    //                wordText = "Băneasa",
    //                hint = "Făină "
    //            },
    //            new Word {
    //                wordText = "Dr. Oetker",
    //                hint = "Aitivi alimentari",
    //                country = Countries.Germany,
    //                startYear = 1981,
    //                about = "În 2002 Dr. Oetker a deschis o unitate de producție lângă Curtea de Argeș, unde se produc majoritatea produselor comer­cializate pe plan local."
    //            },
    //            new Word {
    //                wordText = "Napolact",
    //                hint = "Lactate",
    //                startYear = 1905,
    //                about = "Napolact este un brand al companiei olandeze FrieslandCampina, unul dintre cei mai mari producători de lactate din lume. Brandul este folosit doar în România, unde compania deținea în 2015 două fabrici în județul Cluj și una în Târgu Mureș."
    //            },
    //            new Word {
    //                wordText = "RoStar",
    //                hint = "Biscuiți",
    //                startYear = 1996,
    //                about = "RoStar este o companie producătoare de biscuiți din România cu o capacitate de producție de 50 tone pe zi și 410 angajați."
    //            },
    //            new Word {
    //                wordText = "Olympus",
    //                hint = "Lactate",
    //                country = "Greece",
    //                about = "Olympus Dairy este o companie producătoare de lactate din Grecia. Este prezentă în 34 de țări și are cinci unități de producție, 3 în Grecia și câte una în Bulgaria și România."
    //            },
    //            new Word {
    //                wordText = "Albalact",
    //                hint = "Lactate",
    //                startYear = 1971,
    //                about = "Albalact este o companie românească înființată în 1971 sub denumirea de Întreprinderea de Industrializare a Laptelui Alba."
    //            },
    //            new Word {
    //                wordText = "Danone",
    //                hint = "Lactate",
    //                country = Countries.Spain,
    //                startYear = 1919,
    //                about = "Compania a ajuns în România în anul 1996, prin achiziția activelor unei foste fabrici de lactate din București. Din 1997 își începe operațiunile în România, prin distribuția de produse importate din Polonia și Ungaria. În 1999 Danone începe producția de iaurt în România."
    //            },
    //            new Word {
    //                wordText = "Covalact",
    //                hint = "Lactate",
    //                startYear = 1969,
    //                about = "Covalact este o companie producătoare de produse lactate din România."
    //            },
    //            new Word {
    //                wordText = "Nestlé",
    //                hint = "Produse de cofetărie, cafea",
    //                startYear = 1866,
    //                country = Countries.Switzerland
    //            },
    //            new Word {
    //                wordText = "Nescafe",
    //                hint = "Cafea",
    //                country = Countries.Switzerland,
    //                about = "Cu marca Nescafe, Nestle este cel mai mare jucător pe segmentul cafelei solubile din România."
    //            },
    //            new Word {
    //                wordText = "Vel Pitar",
    //                hint = "Panificație",
    //                startYear = 1990,
    //                about = "Vel Pitar este un grup de companii din România, cu activitate în domeniul morăritului și panificației. Grupul deține 12 fabrici de pâine în zece județe din țară și în București, având peste 170 de magazine proprii (martie 2009)."
    //            }
    //        },
    //     },
    //     #endregion

    //    #region Companii & Servicii
    //     new Category
    //     {
    //        categoryName = "Companii & Servicii",
    //        detailIndex = 0,
    //        words = new Word[]
    //        {
    //            //new Word { wordText = "poșta română", hint = "Apă",  },    
    //            //new Word { wordText = "Regina Maria", hint = "Rețea privată de sănătate", foundedYear=1995,
    //               // about="Numele companiei a venit de la Maria Alexandra Victoria, Prințesa de Edinburgh, nepoata Reginei Victoria a Angliei care în 1914 devine Regina Maria a României. În timpul Primului Război Mondial ea a dedicat cu generozitate bolnavilor și muribunzilor timp și energie din plin." },

    //            new Word {
    //                wordText = "ARO",
    //                hint = "Automobile",
    //                startYear = 1957,
    //                endYear = 2002,
    //                about = "ARO a produs peste 380.000 de vehicule, dintre care două treimi au fost exportate în peste 110 țări"
    //            },
    //            new Word {
    //                wordText = "Pegas",
    //                hint = "Biciclete",
    //                startYear = 1972,
    //                about = "Unul dintre sloganurile fabricii este luat dintr-o scrisoare a scriitorului francez Gustave Flaubert: „Pegas mai des merge decât galopează: tot talentul este să știi să-l strunești ca să meargă cu viteza dorită."
    //            },
    //            new Word {
    //                wordText = "CFR",
    //                hint = "Infrastructură feroviară",
    //                startYear = 1998
    //            },
    //            new Word {
    //                wordText = "LukOil",
    //                hint = "Benzinărie",
    //                startYear = 1991,
    //                country = Countries.Russia,
    //                about = "LukOil este cea mai mare companie petrolieră din Rusia, asigurând circa 20% din producția de țiței rusească (79,8 milioane tone). Rețeaua de stații a produselor petroliere include 4.076 stații în Rusia și în alte țări."
    //            },
    //                            new Word {
    //                wordText = "Allview",
    //                hint = "Smartphone-uri, electronice",
    //                startYear = 2002,
    //                about = "Allview este un brand deținut de compania românească Visual Fan care comercializează smartphone-uri. Activează din 2002 în zona de electronice și fondatorul este Lucian Peticilă."
    //            },
    //            new Word {
    //                wordText = "SuperBet",
    //                hint = "Casă de pariuri",
    //                startYear = 2008,
    //                about = "Superbet a fost fondat în 2008, în București. Prima agenție Superbet este deschisă în Oradea. Compania deschide agenția 500 în anul 2015, iar în august 2017 pe cea cu numărul 600."
    //            },

    //            new Word {
    //                wordText = "ING",
    //                hint = "Servicii bancare",
    //                startYear = 1994,
    //                about = "ING Bank România este parte a ING Group, instituție financiară internațională globală, care oferă servicii bancare unui număr de peste 34 de milioane de clienți individuali, companii sau instituții din peste 40 de țări."
    //            },

    //            new Word {
    //                wordText = "BRD",
    //                hint = "Servicii bancare",
    //                startYear = 1923,
    //                about = "BRD - Groupe Société Générale (Banca Română pentru Dezvoltare), este o bancă românească deținută de grupul financiar francez Société Générale. În 2013, ea a fost a doua bancă din România, după Banca Comercială Română (BCR)."
    //            },
    //            new Word {
    //                wordText = "BCR",
    //                hint = "Servicii bancare",
    //                startYear = 1990
    //            },
    //            new Word {
    //                wordText = "Rompetrol",
    //                hint = "Benzinărie",
    //                startYear = 1974
    //            },
    //            new Word {
    //                wordText = "Dacia",
    //                hint = "Autovehicule",
    //                startYear = 1966
    //            },
    //            new Word {
    //                wordText = "Digi",
    //                hint = "Operator de telecomunicații mobile",
    //                startYear = 1994
    //            },
    //            new Word {
    //                wordText = "Dero",
    //                hint = "Detergent de rufe",
    //                startYear = 1966,
    //                about = "Numele Dero creat in 1966 este o abreviere pentru Detergenti Romania"
    //            },
    //            new Word {
    //                wordText = "Petrom",
    //                hint = "Benzinărie",
    //                startYear = 1991
    //            },
    //            new Word {
    //                wordText = "Arctic",
    //                hint = "Electrocasnice",
    //                startYear = 1968,
    //                about = "Arctic este lider pe piața de produse electrocasnice din România, cu o cotă de piață de 35%."
    //            },
    //            new Word {
    //                wordText = "Trabant",
    //                hint = "Automobile",
    //                startYear = 1957,
    //                endYear = 1991,
    //                country = Countries.Germany,
    //                about = "În Zwickau (Germania) au fost produse în total 3.051.385 de automobile Trabant."
    //            },
    //            new Word {
    //                wordText = "CEC",
    //                hint = "Servicii bancare",
    //                startYear = 1864,
    //                about = "Casa de Economii și Consemnațiuni este o instituție bancară din România, deținută de stat. În august 2009, banca avea 2,7 milioane clienți."
    //            },
    //            new Word {
    //                wordText = "Cargus",
    //                hint = "Curierat",
    //                about = "Urgent Cargus este o companie de curierat rapid din România, prima de acest tip din România. Compania a fost cumpărată de DHL în 2008 pentru o sumă estimată la 50 milioane Euro."
    //            },
    //            new Word {
    //                wordText = "DPD",
    //                hint = "Curierat",
    //                startYear = 1999,
    //                about = "DPD România este o companie de curierat din România. Compania este prezentă și pe piața din Bulgaria de la 1 iulie 2007. În anul 2013 livra zilnic circa 15.000 de colete."
    //            },
    //            new Word {
    //                wordText = "Țiriac Auto",
    //                hint = "Dealer auto",
    //                about = "ȚiriacAuto este divizia auto a grupului Țiriac Holding și este un important importator auto din România. ȚiriacAuto, controlează 12 dealeri din București, Brașov, Cluj, Timișoara, Iași și Oradea. Cifra de afaceri în 2008: 1,2 miliarde euro."
    //            },
    //            new Word {
    //                wordText = "Enel",
    //                hint = "Furnizor energie electrică",
    //                startYear = 1962,
    //                country = Countries.Italy,
    //                about = "Enel este cea mai mare companie italiană implicată în producția și furnizarea energiei electrice. În iulie 2011, Enel avea în România 2,6 milioane de clienți."
    //            },
    //            new Word {
    //                wordText = "Unicredit",
    //                hint = "Servicii bancare",
    //                startYear = 1998,
    //                country = Countries.Italy,
    //                about = "UniCredit (Unicredito Italiano) este un grup financiar-bancar din Italia, cu sediul la Milano, prezent în 20 de țări. În România, grupul UniCredit are o rețea de 242 de unități."
    //            },
    //            new Word {
    //                wordText = "Fan Courier",
    //                hint = "Curierat",
    //                startYear = 1998,
    //                about = "FAN Courier Express este o companie de curierat din România, cu sediul în București și expediază cu propria flotă de 1.500 mașini (sistem „door to door”) plicuri și colete în țară."
    //            },
    //            new Word {
    //                wordText = "NN",
    //                hint = "Asigurări",
    //                startYear = 1963,
    //                country = Countries.Netherlands,
    //                about = "NN Group N.V. este compania-mamă a NN Investment Partners și Nationale-Nederlanden. Nationale-Nederlanden este una dintre cele mai mari companii de asigurări și administrare a activelor din Olanda."
    //            },
    //            new Word {
    //                wordText = "Sameday",
    //                hint = "Curierat",
    //                startYear = 2007
    //            },
    //            new Word {
    //                wordText = "Euroins",
    //                hint = "Asigurări auto",
    //                startYear = 1994,
    //                about = "Euroins România este o companie de asigurări din România. Compania a avut numele de Asitrans până în 2008."
    //            },
    //            new Word {
    //                wordText = "Tarom",
    //                hint = "Servicii aeriene"
    //            },
    //        },

    //        bonusWords = new Word[]
    //        {
    //            new Word {
    //                wordText = "GLS",
    //                hint = "Curierat",
    //                isGuess = true,
    //                startYear = 1999,
    //                country = Countries.Netherlands,
    //                variants = new List<string>{ "DPD","GPS", "VLC"},
    //                about = "General Logistics Systems B.V., cunoscută și sub numele de GLS, este o companie de logistică britanică cu sediul în Amsterdam, Olanda. Compania a fost cunoscută sub numele de German Parcel când a fost fondată în 1989, de Rico Back."
    //            }
    //        }
    //     },
    //     #endregion
                
    //    #region Politică & Sport
    //    new Category
    //     {
    //        categoryName = "Politică & Sport",
    //        words = new Word[]
    //        {
    //            new Word { wordText = "Steaua", hint = "Echipă de fotbal din București" },
    //            new Word { wordText = "Voluntari", hint = "Echipă de fotbal" },
    //            new Word { wordText = "Botoșani", hint = "Echipă de fotbal" },
    //            new Word { wordText = "Rapid", hint = "Echipă de fotbal din București" },
    //            new Word { wordText = "Dinamo", hint = "Echipă de fotbal din București" },
    //            new Word { wordText = "Astra Giurgiu", hint = "Echipă de fotbal" },
    //            new Word { wordText = "Viitorul", hint = "Echipă de fotbal" },

    //            new Word { wordText = "PSD", hint = "Partid de centru-stânga ", about = "Partidul Social Democrat", startYear = 2001 },
    //            new Word { wordText = "UDMR", hint = "Partid de centru-dreapta", about = "Uniunea Democrată Maghiară din România", startYear = 1989 },
    //            new Word { wordText = "PMP", hint = "Partid de centru-dreapta", about = "Partidul Mișcarea Populară", startYear = 2014 },
    //            new Word { wordText = "PRO", hint = "Partid de centru", about = "PRO România Social-Liberal", startYear = 2020 },
    //            new Word { wordText = "PNL", hint = "Partid de centru-dreapta", about = "Partidul Național Liberal", startYear = 1875 },
    //            new Word { wordText = "USR", hint = "Partid de centru-dreapta", about = "Uniunea Salvați România", startYear = 2019 },
    //            new Word { wordText = "AUR", hint = "Partid de centru-dreapta", about = "Alianța pentru Unirea Românilor", startYear = 2019 },
    //            new Word { wordText = "PV", hint = "Partid de centru", about = "Partidul Verde", startYear = 2005 },
    //            new Word { wordText = "PRM", hint = "Partid de centru-stânga", about = "Partidul România Mare", startYear = 1991 }
    //        }
    //     },
    //    #endregion
    //};
}