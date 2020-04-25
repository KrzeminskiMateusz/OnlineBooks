using OnlineBooksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBooksApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            var authors = new Author[]
            {
                new Author{ FirstName = "Krzysztof Kamil", LastName = "Baczyński", Nationality = "Polska", DataOfBirth = DateTime.Parse("22/01/1921"), PlaceOfBirth = "Warszawa", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("04/08/1944"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska",Description="Polski poeta czasu wojny, podchorąży Armii Krajowej, podharcmistrz Szarych Szeregów, jeden z przedstawicieli pokolenia Kolumbów, w czasie okupacji związany z pismem „Płomienie” oraz miesięcznikiem „Droga”. Zginął w czasie powstania warszawskiego jako żołnierz batalionu „Parasol” Armii Krajowej."},
                new Author{ FirstName = "Jan", LastName = "Brzechwa", Nationality = "Polska", DataOfBirth = DateTime.Parse("15/08/1898"), PlaceOfBirth = "Żmerynka", CountryOfBirth = "Ukrainie",
                DateOfDeath =DateTime.Parse("02/07/1966"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska",Description="Polski poeta pochodzenia żydowskiego, autor bajek i wierszy dla dzieci, satyrycznych tekstów dla dorosłych, a także tłumacz literatury rosyjskiej."},
                new Author{ FirstName = "Jan", LastName = "Długosz", Nationality = "Polska", DataOfBirth = DateTime.Parse("01/12/1415"), PlaceOfBirth = "Stara Brzeźnica", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("19/05/1480"), PlaceOfDeath="Kraków", CountryOfDeath="Polska",Description="Polski historyk, kronikarz, twórca dzieła Historia[1], duchowny, geograf, pierwszy heraldyk polski, dyplomata; wychowawca synów Kazimierza Jagiellończyka, posiadał przywilej kreacji notarialnej."},
                new Author{ FirstName = "Aleksander", LastName = "Fredro", Nationality = "Polska", DataOfBirth = DateTime.Parse("20/06/1793"), PlaceOfBirth = "Surochów", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("15/07/1876"), PlaceOfDeath="Lwów", CountryOfDeath="Ukraina",Description=@"Polski komediopisarz i poeta.\n"
                + @"/n"
                + @"Pochodził z szeroko rozgałęzionego rodu szlacheckiego, który w 1822 r. uzyskał tytuł hrabiowski. W r. 1809 wstąpił do armii Księstwa Warszawskiego, brał udział w wojnie z Rosją w 1812 r. (wojny napoleońskie), zbiegł z rosyjskiej niewoli.\n"
                + @"/n"
                + @"W r. 1815 osiadł w rodzinnym majątku Bieńkowa Wisznia pod Lwowem. W 1828 ożenił się z hrabiną Z.Skarbkową.W latach 1833 - 1842 był posłem do Sejmu Stanowego. Od r. 1850 przez pięć lat mieszkał wraz z rodziną w Paryżu.W 1839 r.został honorowym obywatelem miasta Lwowa.Od r. 1873 był członkiem Akademii Umiejętności.\n"
                + @"/n"
                + @"Uważany za najwybitniejszego polskiego komediopisarza, tworzył z wieloletnimi przerwami, odmawiając publikowania niektórych utworów w miarę ich powstawania, m.in. z powodu ataków krytyki.\n"
                + @"/n"
                + @"Jego komedie obyczajowe zajmują się głównie życiem codziennym szlachty galicyjskiej w I. połowie XIX w., kreując barwne i charakterystyczne typy sceniczne. Stał się mistrzem portretu psychologicznego.\n"
                + @"/n"
                + @"Najwybitniejsze komedie napisał w pierwszym okresie twórczości, do 1835: Pan Geldhab(1818, wyst. 1821), Mąż i żona(wyst. 1822), Pan Jowialski(wyst. 1832), Śluby panieńskie, czyli Magnetyzm serca(wyst. 1833), Zemsta(wyst. 1834), Dożywocie(wyst. 1835).\n"
                + @"/n"
                + @"W drugim okresie twórczości, po 18 - letnim milczeniu, wyróżnić trzeba Wielkiego człowieka do małych interesów(wyst. 1877). Wszystkie te utwory stanowią klasykę teatru polskiego."},
                new Author{ FirstName = "Konstanty Ildefons", LastName = "Gałczyński", Nationality = "Polska", DataOfBirth = DateTime.Parse("23/01/1905"), PlaceOfBirth = "Warszawa", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("06/12/1953"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska",Description="Polski poeta. Najbardziej znany za sprawą paradramatycznej serii podszytych absurdem humoresek Teatrzyk Zielona Gęś, w której pojawiła się galeria postaci takich jak Osiołek Porfirion, Piekielny Piotruś, Hermenegilda Kociubińska czy Zielona Gęś."},
                new Author{ FirstName = "Witold", LastName = "Gombrowicz", Nationality = "Polska", DataOfBirth = DateTime.Parse("04/08/1904"), PlaceOfBirth = "Małoszyce", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("24/07/1969"), PlaceOfDeath="Vence", CountryOfDeath="Francja",Description="Polski powieściopisarz, nowelista i dramaturg. Jeden z najwybitniejszych polskich pisarzy XX wieku. Jego twórczość cechuje głęboka analiza psychologiczna człowieka jako uwikłanego w spuściznę kultury i w innych ludzi, analiza tożsamości jednostki w interakcji z innymi, problemu niedojrzałości i młodości, ról klasowych, a także poczucie absurdu, obrazoburstwo względem przyjmowanych przez społeczeństwo tradycyjnych wartości, antynacjonalizm i krytyka romantyzmu. Te elementy przeplatały się w jego najważniejszych utworach: powieściach Ferdydurke (1937), Trans-Atlantyk (1953), Pornografia (1960) i Kosmos (1965), oraz dramatach, m.in. Iwona, księżniczka Burgunda (1938) oraz Ślub (1953). Od 1939 Gombrowicz przebywał na emigracji: do 1963 w Argentynie, od 1964 aż do śmierci we Francji. Ważną częścią jego twórczości był prowadzony w latach 1953–1969 Dziennik, w którym autor w sposób ironiczny, cyniczny i z humorem opowiadał własne losy, podejmował dialog z różnymi nurtami filozoficznymi, z tradycją kultury polskiej i komentował bieżące wydarzenia polityczne. Zyskał sławę dopiero w ostatnich latach życia, był wówczas wśród kandydatów do Nagrody Nobla w dziedzinie literatury (1966, 1968, 1969), której jednak nie otrzymał."},
                new Author{ FirstName = "Zbigniew", LastName = "Herbert", Nationality = "Polska", DataOfBirth = DateTime.Parse("29/10/1924"), PlaceOfBirth = "Lwów", CountryOfBirth = "Ukraina",
                DateOfDeath =DateTime.Parse("28/07/1998"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska",Description= @"Polski poeta, eseista, dramaturg, twórca słynnego cyklu poetyckiego „Pan Cogito”, autor słuchowisk; pośmiertnie odznaczony Orderem Orła Białego. Z wykształcenia ekonomista, prawnik i filozof.\n"
                + @"Laureat ponad dwudziestu nagród literackich. Od końca lat 60. XX w. był jednym z najpoważniejszych pretendentów do Literackiej Nagrody Nobla.Jego książki zostały przetłumaczone na 38 języków."},
                new Author{ FirstName = "Ryszard", LastName = "Kapuściński", Nationality = "Polska", DataOfBirth = DateTime.Parse("04/03/1932"), PlaceOfBirth = "Pińsk", CountryOfBirth = "Białorusi",
                DateOfDeath =DateTime.Parse("23/01/2007"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska",Description= @"Polski reportażysta, publicysta, poeta i fotograf, zwany „cesarzem reportażu”.\n"
                + @"Jest najczęściej, obok Stanisława Lema, tłumaczonym polskim autorem."},
                new Author{ FirstName = "Jan", LastName = "Kochanowski", Nationality = "Polska", PlaceOfBirth = "Sycyna Północna", CountryOfBirth = "Polska", IsAlive = false,
                DateOfDeath =DateTime.Parse("22/08/1584"), PlaceOfDeath="Lublin", CountryOfDeath="Polska",Description="Polski poeta epoki renesansu, tłumacz, prepozyt kapituły katedralnej poznańskiej w latach 1564–1574, poeta nadworny Stefana Batorego w 1579 roku, sekretarz królewski i wojski sandomierski w latach 1579–1584. Uważany jest za jednego z najwybitniejszych twórców renesansu w Europie i poetę, który najbardziej przyczynił się do rozwoju polskiego języka literackiego."},
                new Author{ FirstName = "Maria", LastName = "Konopnicka", Nationality = "Polska", DataOfBirth = DateTime.Parse("23/05/1842"), PlaceOfBirth = "Suwałki", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("08/10/1910"), PlaceOfDeath="Lwów", CountryOfDeath="Ukraina"},
                new Author{ FirstName = "Hanna", LastName = "Krall", Nationality = "Polska", DataOfBirth = DateTime.Parse("20/05/1935"), PlaceOfBirth = "Warszawa", CountryOfBirth = "Polska",
                Description="Polska pisarka i dziennikarka."},
                new Author{ FirstName = "Ignacy", LastName = "Krasicki", Nationality = "Polska", DataOfBirth = DateTime.Parse("03/02/1735"), PlaceOfBirth = "Dubiecko", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("14/03/1801"), PlaceOfDeath="Berlin", CountryOfDeath="Niemcy",Description=@"Biskup warmiński od 1767, arcybiskup gnieźnieński od 1795, książę sambijski, hrabia Świętego Cesarstwa Rzymskiego, prezydent Trybunału Głównego Koronnego w Lublinie w 1765, proboszcz przemyski, kustosz kapituły katedralnej lwowskiej w 1765 roku, poeta, prozaik, publicysta i encyklopedysta, kawaler maltański zaszczycony Krzyżem Devotionis, mianowany biskupem tytularnym Verinopolis w 1766 roku.\n"
                + @"/n"
                + @"Jeden z głównych przedstawicieli polskiego oświecenia. Nazywany „księciem poetów polskich”.\n"
                + @"/n"
                + @"Jako biskup warmiński (stąd pseudonim X.B.W. – książę biskup warmiński) z rozmachem urządzał swoje rezydencje w Lidzbarku Warmińskim i Smolajnach. Z racji pełnionej funkcji zasiadał w Senacie Rzeczypospolitej.\n"
                + @"/n"
                + @"W roku 1781 wydał nakładem drukarni Michała Grölla w Warszawie 2-tomowy Zbiór potrzebniejszych wiadomości, trzecią po Inventores rerum Jan Protasowicza, Nowych Atenach polską encyklopedię powszechną. Jest również autorem dzieła uznawanego za pierwszą polską powieść (Mikołaja Doświadczyńskiego przypadki). Tworzył głównie bajki, satyry i poematy heroikomiczne."},
                new Author{ FirstName = "Zygmunt", LastName = "Krasiński", Nationality = "Polska", DataOfBirth = DateTime.Parse("19/02/1812"), PlaceOfBirth = "Paryż", CountryOfBirth = "Francja",
                DateOfDeath =DateTime.Parse("23/02/1859"), PlaceOfDeath="Paryż", CountryOfDeath="Francja"},
                new Author{ FirstName = "Stanisław", LastName = "Lem", Nationality = "Polska", DataOfBirth = DateTime.Parse("12/09/1921"), PlaceOfBirth = "Lwów", CountryOfBirth = "Ukraina",
                DateOfDeath =DateTime.Parse("27/03/2006"), PlaceOfDeath="Kraków", CountryOfDeath="Polska",Description= @"Jego debiutem książkowym była wydana w 1951 roku powieść Astronauci. Kolejne powieści fantastyczno-naukowe jego autorstwa to: Obłok Magellana (1955), Eden (1959), Pamiętnik znaleziony w wannie (1961), Powrót z gwiazd (1961), Solaris (1961), Niezwyciężony (1964), Głos Pana (1968), Wizja lokalna (1982), Fiasko (1987) i Pokój na Ziemi (1987). Był również autorem trylogii Czas nieutracony (1955) oraz cyklu groteskowych opowiadań fantastyczno-naukowych: Dzienniki gwiazdowe (1957), Księga robotów (1961), Bajki robotów (1964), Cyberiada (1965), Opowieści o pilocie Pirxie (1968). Napisał recenzje nieistniejących książek (Doskonała próżnia, 1971), a także wstępy do nieistniejących dzieł (Wielkość urojona, 1973). Jest autorem zbiorów esejów, felietonów i publicystyki literackiej, w tym: Wejście na orbitę (1962), Summa technologiae (1964), Filozofia przypadku (1968), Fantastyka i futurologia (1970), Rozprawy i szkice (1975).\n"
                + @"/n"
                + @"Jego twórczość porusza tematy takie jak: rozwój nauki i techniki, natura ludzka, możliwość porozumienia się istot inteligentnych czy miejsce człowieka we Wszechświecie. Dzieła Lema zawierają odniesienia do stanu współczesnego społeczeństwa i refleksje naukowo - filozoficzne na jego temat.\n"
                + @"/n"
                + @"Jest najczęściej tłumaczonym polskim pisarzem, a w pewnym okresie był najbardziej poczytnym nieanglojęzycznym pisarzem SF, mimo małego odbioru w Stanach Zjednoczonych.Jego książki przetłumaczono na ponad 40 języków, osiągnęły łączny nakład ponad 30 milionów egzemplarzy.\n"
                + @"/n"
                + @"Otrzymał kandydaturę do literackiej Nagrody Nobla.Ostatecznie przyznano ją, jednak Czesławowi Miłoszowi w 1980.\n"
                + @"/n"
                + @"Był odznaczony między innymi medalem „Gloria Artis” i najwyższym polskim odznaczeniem państwowym Orderem Orła Białego. Jego nazwiskiem nazwano planetoidę oraz pierwszego polskiego satelitę naukowego."},
                new Author{ FirstName = "Bolesław", LastName = "Leśmian", Nationality = "Polska", DataOfBirth = DateTime.Parse("22/01/1877"), PlaceOfBirth = "Warszawa", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("05/11/1937"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska"},
                new Author{ FirstName = "Adam", LastName = "Mickiewicz", Nationality = "Polska", DataOfBirth = DateTime.Parse("24/12/1798"), PlaceOfBirth = "Zaosie", CountryOfBirth = "Białorusi",
                DateOfDeath =DateTime.Parse("26/11/1855"), PlaceOfDeath="Konstantynopol", CountryOfDeath="Turcja",Description=@"Polski poeta, działacz polityczny, publicysta, tłumacz, filozof, działacz religijny, mistyk, organizator i dowódca wojskowy, nauczyciel akademicki.\n"
                + @"/n"
                + @"Obok Juliusza Słowackiego i Zygmunta Krasińskiego uważany za największego poetę polskiego romantyzmu (zaliczany do grona tzw. Trzech Wieszczów) oraz literatury polskiej, a nawet za jednego z największych na skalę europejską.Określany też przez innych, jako poeta przeobrażeń oraz bard słowiański.\n"
                + @"/n"
                + @"Członek i założyciel Towarzystwa Filomatycznego, mesjanista związany z Kołem Sprawy Bożej Andrzeja Towiańskiego. Jeden z najwybitniejszych twórców dramatu romantycznego w Polsce, zarówno w ojczyźnie, jak i w zachodniej Europie porównywany do Byrona i Goethego.W okresie pobytu w Paryżu był wykładowcą literatury słowiańskiej w Collège de France. Znany przede wszystkim jako autor ballad, powieści poetyckich, dramatu Dziady oraz epopei narodowej Pan Tadeusz uznawanej za ostatni wielki epos kultury szlacheckiej w Rzeczypospolitej Obojga Narodów. Narodowy poeta Polski, Litwy i Białorusi.Działacz niepodległościowy, organizator polskich oddziałów do walki z Rosją, bonapartysta.\n"
                + @"/n"
                + @"Jego dzieła L’Église officielle et le messianisme oraz L’Église et le Messie umieszczone zostały w index librorum prohibitorum dekretami z 1848 roku."},
                new Author{ FirstName = "Czesław", LastName = "Miłosz", Nationality = "Polska", DataOfBirth = DateTime.Parse("30/06/1911"), PlaceOfBirth = "Szetejnie", CountryOfBirth = "Litwa",
                DateOfDeath =DateTime.Parse("14/08/2004"), PlaceOfDeath="Kraków", CountryOfDeath=@"Polska",Description="Polski poeta, prozaik, eseista, historyk literatury, tłumacz, dyplomata; w latach 1951–1993 przebywał na emigracji, do 1960 we Francji, następnie w Stanach Zjednoczonych; w Polsce do 1980 obłożony cenzurą; laureat Nagrody Nobla w dziedzinie literatury (1980); profesor Uniwersytetu Kalifornijskiego w Berkeley i Uniwersytetu Harvarda; pochowany w Krypcie Zasłużonych na Skałce; brat Andrzeja Miłosza. Uznawany za najwybitniejszego polskiego poetę XX wieku.\n"
                + @"Przed II wojną światową Miłosz był poetą katastroficznym, uderzającym w ton wizyjny stylizacją na głos starotestamentowych proroków. Od innych twórców formacji Żagary odróżniał go kult klasycystycznych rygorów. Po wojnie jego poezja stała się bardziej intelektualna; wiązała się z ambicjami odbudowania trwałych wartości europejskiej kultury, sumienia i wiary.Literaturę pojmował wówczas jako drogę do ocalenia po klęsce poczucia człowieczeństwa. W latach 70.zaczęła w niej dominować tematyka religijna i kontemplacyjna.Jego książki zostały przetłumaczone na 44 języki."},
                new Author{ FirstName = "Jan Andrzej", LastName = "Morsztyn", Nationality = "Polska", DataOfBirth = DateTime.Parse("24/06/1621"), PlaceOfBirth = "Wiśnicz", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("08/01/1693"), PlaceOfDeath="Paryż", CountryOfDeath="Francja",Description="Polityk, poeta, podskarbi wielki koronny w latach 1668–1683, świecki referendarz koronny w latach 1658–1668, stolnik sandomierski w latach 1647–1658, sekretarz królewski w 1656 roku, starosta tucholski w latach 1667–1669 i 1673–1681, warcki od 1661 roku, tymbarski w 1658 roku, kowalski w latach 1658–1672, zawichojski od 1656 roku, ambasador Rzeczypospolitej w Królestwie Francji w 1679 roku."},
                new Author{ FirstName = "Sławomir", LastName = "Mrożek", Nationality = "Polska", DataOfBirth = DateTime.Parse("29/06/1930"), PlaceOfBirth = "Borzęcin", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("15/08/2013"), PlaceOfDeath="Nicea", CountryOfDeath="Francja",Description="Polski pisarz oraz rysownik. Autor satyrycznych opowiadań i utworów dramatycznych o tematyce filozoficznej, politycznej, obyczajowej i psychologicznej. Jako dramaturg zaliczany do nurtu teatru absurdu."},
                new Author{ FirstName = "Małgorzata", LastName = "Musierowicz", Nationality = "Polska", DataOfBirth = DateTime.Parse("09/01/1945"), PlaceOfBirth = "Poznaniu", CountryOfBirth = "Polska",},
                new Author{ FirstName = "Cyprian Kamil", LastName = "Norwid", Nationality = "Polska", DataOfBirth = DateTime.Parse("24/09/1821"), PlaceOfBirth = "Głuchy", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("23/05/1883"), PlaceOfDeath="Paryż", CountryOfDeath="Francja",Description=@"Polski poeta, prozaik, dramatopisarz, eseista, grafik, rzeźbiarz, malarz i filozof.\n"
                + @"/n"
                + @"Często uznawany za ostatniego z czterech najważniejszych polskich poetów romantycznych. Wielu historyków literatury uważa jednak taki pogląd za zbytnie uproszczenie, zaliczając jego twórczość raczej do klasycyzmu i parnasizmu.\n"
                + @"/n"
                + @"Przeważającą część swojego życia spędził za granicą, głównie w Paryżu, żyjąc w nędzy i utrzymując się z prac dorywczych.Twórczość Norwida, trudna do zrozumienia dla jemu współczesnych, została zapomniana po jego śmierci.Został odkryty ponownie dopiero w okresie Młodej Polski głównie za sprawą Zenona Przesmyckiego - Miriama(po części również młodego Władysława Stanisława Reymonta)."},
                new Author{ FirstName = "Eliza", LastName = "Orzeszkowa", Nationality = "Polska", DataOfBirth = DateTime.Parse("06/06/1841"), PlaceOfBirth = "Milkowszczyzna", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("18/05/1910"), PlaceOfDeath="Grodno", CountryOfDeath="Białoruś",Description="Polska pisarka epoki pozytywizmu, autorka powieści Nad Niemnem (1888), nominowana do Nagrody Nobla w dziedzinie literatury w 1905. Jedna z najwybitniejszych powieściopisarek w okresie polskiego pozytywizmu."},
                new Author{ FirstName = "Bolesław", LastName = "Prus", Nationality = "Polska", DataOfBirth = DateTime.Parse("20/08/1847"), PlaceOfBirth = "Hrubieszów", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("19/05/1912"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska",Description="Polski pisarz, prozaik, nowelista i publicysta okresu pozytywizmu, współtwórca polskiego realizmu, kronikarz Warszawy, myśliciel i popularyzator wiedzy, działacz społeczny, propagator turystyki pieszej i rowerowej. Jeden z najwybitniejszych i najważniejszych pisarzy w historii literatury polskiej."},
                new Author{ FirstName = "Władysław", LastName = "Reymont", Nationality = "Polska", DataOfBirth = DateTime.Parse("07/05/1867"), PlaceOfBirth = "Kobiele Wielkie", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("05/12/1925"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska",Description="Polski pisarz, prozaik i nowelista, jeden z głównych przedstawicieli realizmu z elementami naturalizmu w prozie Młodej Polski. Niewielką część jego spuścizny stanowią wiersze. Laureat Nagrody Nobla w dziedzinie literatury za czterotomową „epopeję chłopską” Chłopi. Jeden z najwybitniejszych i najważniejszych pisarzy w dziejach literatury polskiej."},
                new Author{ FirstName = "Henryk", LastName = "Sienkiewicz", Nationality = "Polska", DataOfBirth = DateTime.Parse("05/05/1846"), PlaceOfBirth = "Wola Okrzejska", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("15/11/1916"), PlaceOfDeath="Vevey", CountryOfDeath="Szwajcaria",Description="Polski nowelista, powieściopisarz i publicysta; laureat Nagrody Nobla w dziedzinie literatury (1905) za całokształt twórczości, jeden z najpopularniejszych polskich pisarzy przełomu XIX i XX w."},
                new Author{ FirstName = "Juliusz", LastName = "Słowacki", Nationality = "Polska", DataOfBirth = DateTime.Parse("04/09/1809"), PlaceOfBirth = "Krzemieniec", CountryOfBirth = "Ukraina",
                DateOfDeath =DateTime.Parse("03/04/1849"), PlaceOfDeath="Paryż", CountryOfDeath="Francja",Description=@"Polski poeta, przedstawiciel romantyzmu, dramaturg i epistolograf. Obok Mickiewicza i Krasińskiego określany jako jeden z Wieszczów Narodowych. Twórca filozofii genezyjskiej (pneumatycznej), epizodycznie związany także z mesjanizmem polskim, był też mistykiem. Obok Mickiewicza uznawany powszechnie za największego przedstawiciela polskiego romantyzmu.\n"
                + @"/n"
                + @"Utwory Słowackiego, zgodnie z duchem epoki i ówczesną sytuacją narodu polskiego, podejmowały istotne problemy związane z walką narodowowyzwoleńczą, z przeszłością narodu i przyczynami niewoli, ale także poruszały uniwersalne tematy egzystencjalne. Jego twórczość wyróżniała się mistycyzmem, wspaniałym bogactwem wyobraźni, poetyckich przenośni i języka. Jako liryk zasłynął pieśniami odwołującymi się do Orientu, źródeł ludowych i słowiańszczyzny. Był poetą nastrojów, mistrzem operowania słowem.Obok Cypriana Kamila Norwida i Tadeusza Micińskiego uważany za największego z mistyków polskiej poezji. Miał zresztą(i opisał je w Raptularzu) doświadczenia mistyczne.\n"
                + @"/n"
                + @"Wywarł ogromny wpływ na późniejszych poetów Młodej Polski i dwudziestolecia międzywojennego, m.in. Antoniego Langego, Krzysztofa Kamila Baczyńskiego, Jana Lechonia. 9 stycznia 2009 Sejm Rzeczypospolitej Polskiej ogłosił rok 2009 Rokiem Juliusza Słowackiego."},
                new Author{ FirstName = "Wisława", LastName = "Szymborska", Nationality = "Polska", DataOfBirth = DateTime.Parse("02/07/1923"), PlaceOfBirth = "Kórnik", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("04/02/2012"), PlaceOfDeath="Kraków", CountryOfDeath="Polska",Description="Polska poetka, eseistka, krytyczka, tłumaczka, felietonistka; laureatka Nagrody Nobla w dziedzinie literatury (1996), członek założyciel Stowarzyszenia Pisarzy Polskich (1989), członkini Polskiej Akademii Umiejętności (1995), dama Orderu Orła Białego."},
                new Author{ FirstName = "Julian", LastName = "Tuwim", Nationality = "Polska", DataOfBirth = DateTime.Parse("13/09/1894"), PlaceOfBirth = "Łódź", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("27/12/1953"), PlaceOfDeath="Zakopane", CountryOfDeath="Polska",Description="olski poeta żydowskiego pochodzenia, pisarz, autor wodewili, skeczy, librett operetkowych i tekstów piosenek; jeden z najpopularniejszych poetów dwudziestolecia międzywojennego. Współzałożyciel kabaretu literackiego „Pod Picadorem” i grupy poetyckiej „Skamander”. Bliski współpracownik tygodnika „Wiadomości Literackie”. Tłumacz poezji rosyjskiej, francuskiej, niemieckiej oraz łacińskiej. Brat polskiej literatki i tłumaczki Ireny Tuwim, kuzyn aktora kabaretowego i piosenkarza Kazimierza „Lopka” Krukowskiego. Jego bratem stryjecznym był aktor Włodzimierz Boruński. Podpisywał się ponad czterdziestoma pseudonimami m.in. Oldlen, Tuvim, Schyzio Frenik, Jan Wim, Pikador, Roch Pekiński, Owóż, Czyliżem, Atoli, Wszak."},
                new Author{ FirstName = "Stanisław Ignacy", LastName = "Witkiewicz", Nationality = "Polska", DataOfBirth = DateTime.Parse("24/02/1885"), PlaceOfBirth = "Warszawa", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("18/09/1939"), PlaceOfDeath="Jeziory", CountryOfDeath="Ukraina",Description="Polski pisarz, malarz, filozof, dramaturg i fotografik."},
                new Author{ FirstName = "Stanisław", LastName = "Wyspiański", Nationality = "Polska", DataOfBirth = DateTime.Parse("15/01/1869"), PlaceOfBirth = "Kraków", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("28/11/1907"), PlaceOfDeath="Kraków", CountryOfDeath="Polska",Description="Polski dramaturg, poeta, malarz, grafik, architekt, projektant mebli. Jako pisarz związany z dramatem symbolicznym. Tworzył w epoce Młodej Polski. Bywa nazywany czwartym wieszczem polskim."},
                new Author{ FirstName = "Stefan", LastName = "Żeromski", Nationality = "Polska", DataOfBirth = DateTime.Parse("14/10/1864"), PlaceOfBirth = "Strawczyn", CountryOfBirth = "Polska",
                DateOfDeath =DateTime.Parse("20/11/1925"), PlaceOfDeath="Warszawa", CountryOfDeath="Polska",Description=@"Polski prozaik, publicysta, dramaturg; pierwszy prezes polskiego PEN Clubu. Czterokrotnie nominowany do Nagrody Nobla w dziedzinie literatury (1921, 1922, 1923, 1924). Jeden z najwybitniejszych pisarzy polskich w historii.\n"
                + @"Stefan Żeromski był znany również pod pseudonimami Maurycy Zych, Józef Katerla i Stefan Iksmoreż. Ze względu na zaangażowanie społeczne nazwany był „sumieniem polskiej literatury” lub „sumieniem narodu”."}
            };

            foreach (Author author in authors)
            {
                context.Authors.Add(author);
            }
            context.SaveChanges();

            var books = new Book[]
            {
                new Book{Title="Wybór poezji", AuthorId = authors.Single(x => x.LastName == "Baczyński").Id, PublcationDate=DateTime.Parse("01/01/1998"), NumberOfPages = 416,
                Description=""},
                new Book{Title="Utwory wybrane ", AuthorId = authors.Single(x => x.LastName == "Baczyński").Id, PublcationDate=DateTime.Parse("04/04/1970"), NumberOfPages = 365},
                new Book{Title="Liryki najpiękniejsze. Baczyński ", AuthorId = authors.Single(x => x.LastName == "Baczyński").Id, NumberOfPages = 160,
                Description="Pięknie wydany wybór wierszy."},
                new Book{Title="Akademia Pana Kleksa", AuthorId = authors.Single(x => x.LastName == "Brzechwa").Id, PublcationDate=DateTime.Parse("01/01/1964"), NumberOfPages = 136,
                Description="Nazywam się Adam Niezgódka, mam dwanaście lat i już od pół roku jestem w Akademii pana Kleksa. W domu nic mi się nigdy nie udawało. Zawsze spóźniałem się do szkoły, nigdy nie zdążyłem odrobić lekcji i miałem gliniane ręce. Wszystko upuszczałem na podłogę i tłukłem, a szklanki i spodki na sam mój widok pękały i rozlatywały się w drobne kawałki, zanim jeszcze zdążyłem ich dotknąć. Nie znosiłem krupniku i marchewki, a właśnie codziennie dostawałem na obiad krupnik i marchewkę, bo to pożywne i zdrowe. Kiedy na domiar złego oblałem atramentem parę spodni, obrus i nowy kostium mamy, rodzice postanowili wysłać mnie na naukę i wychowanie do papa Kleksa."},
                new Book{Title="Brzechwa dzieciom", AuthorId = authors.Single(x => x.LastName == "Brzechwa").Id, PublcationDate=DateTime.Parse("01/01/1955"), NumberOfPages = 144 ,
                Description=@"Brzechwa dzieciom to dobrze znany zbiór najpiękniejszych wierszy Jana Brzechwy dla dzieci. Nasze najnowsze wydanie na kredowym papierze z pewnością przyciągnie uwagę dzieci kolorową, trwałą okładką, pokrytą miłą w dotyku folią satynową wraz z zastosowanym wybiórczo błyszczącym lakierem, co sprawia, że całość wspaniale się prezentuje.\n"
                + @"Ciepłe i niezwykle kolorowe ilustracje autorstwa Marka Szala idealnie obrazują ciepły i wesoły świat wierszy Brzechwy. To pozycja, którą każde dziecko po prostu musi mieć w domu!\n"
                + @"Wydanie w serii Kolorowa Klasyka zawiera szeroki wybór najpiękniejszych wierszy Jana Brzechwy dla dzieci - utwory jak Kaczka-dziwaczka, Sójka, Kłamczucha, czy Leń - to klasyka literatury dziecięcej, bez której dzieciństwo wielu z nas nie byłoby takie samo!"},
                new Book{Title="Pchła Szachrajka", AuthorId = authors.Single(x => x.LastName == "Brzechwa").Id, PublcationDate=DateTime.Parse("01/01/1957"), NumberOfPages = 64,
                Description=@"Chcecie bajki? Oto bajka:\n"
                + @"Była sobie Pchła Szachrajka.\n"
                + @"Niesłychana rzecz po prostu,\n"
                + @"By ktoś tak marnego wzrostu\n"
                + @"I nędznego pchlego rodu\n"
                + @"Mógł wyczyniać bez powodu\n"
                + @"Takie psoty i gałgaństwa,\n"
                + @"Jak pchła owa, proszę państwa."},
                new Book{Title="Tańcowała igła z nitką ", AuthorId = authors.Single(x => x.LastName == "Brzechwa").Id, PublcationDate=DateTime.Parse("01/01/1963"), NumberOfPages = 10,
                Description=@"Tańcowała igła z nitką,\n"
                + @"Igła - pięknie, nitka - brzydko.\n"
                + @"\n"
                + @"Igła cała jak z igiełki,\n"
                + @"Nitce plączą się supełki.\n"
                + @"\n"
                + @"Igła naprzód - nitka za nią:\n"
                +@"„Ach, jak cudnie tańczyć z panią!”\n"
                +@"\n"
                + @"Igła biegnie drobnym ściegiem,\n"
                + @"A za igłą -nitka biegiem....\n"},
                new Book{Title="Roczniki czyli Kroniki sławnego Królestwa Polskiego, księga 1 i 2", AuthorId = authors.Single(x => x.LastName == "Długosz").Id, PublcationDate=DateTime.Parse("01/01/2019"), NumberOfPages = 448 ,
                Description=""},
                new Book{Title="Śluby panieńskie", AuthorId = authors.Single(x => x.LastName == "Fredro").Id, PublcationDate=DateTime.Parse("01/01/1926"),
                Description=@"Śluby panieńskie, czyli Magnetyzm serca jest pisaną wierszem komedią w pięciu aktach Aleksandra Fredry należącą do kanonu polskiej literatury dramatycznej. Tematem utworu jest miłość. Dwie piękne dziewczyny, Aniela i Klara, składają sobie przysięgę, że nigdy nie wyjdą za mąż i będą skazywały mężczyzn na cierpienia swoją obojętnością. Zakochani w nich Gustaw i Albin przeżywają katusze. Gustaw knuje skomplikowaną intrygę, aby zdobyć serce ukochanej. Z komedii wyłania się Fredrowska wizja miłości, ukazana jako niewidzialna potęga oddziaływająca na człowieka i pobudzająca go do najtrudniejszych czynów. Siła miłości jest według Fredry najgłębszym źródłem ludzkiego szczęścia. Komedia Aleksandra Fredry od prawie dwóch wieków cieszy się niesłabnącym powodzeniem wśród wielbicieli teatru, należy do żelaznego repertuaru polskiej sceny, była przedmiotem ekranizacji telewizyjnych i filmowych.\n"
                + @"Lektura dla szkół średnich"},
                new Book{Title="Zemsta", AuthorId = authors.Single(x => x.LastName == "Fredro").Id, PublcationDate=DateTime.Parse("01/01/1928"), NumberOfPages = 150 ,
                Description="Cześnik Raptusiewicz i Rejent Milczek mieszkają w jednym zamku. Ich życie upływa na kłótniach i intrygach. Życie Wacława Rejentowicza i Klary Raptusiewiczówny - wprost przeciwnie. Młodzi są zakochani, planują wspólną przyszłość, dlatego robią wszystko, by pogodzić zwaśnionych sąsiadów. Czy pojedynek Cześnika i Rejenta dojdzie do skutku, czy też miłość zatryumfuje nad przemożnym pragnieniem zemsty?"},
                new Book{Title="Zielona Gęś. Najmniejszy teatr świata ", AuthorId = authors.Single(x => x.LastName == "Gałczyński").Id, NumberOfPages = 472 },
                new Book{Title="Ferdydurke", AuthorId = authors.Single(x => x.LastName == "Gombrowicz").Id, PublcationDate=DateTime.Parse("01/01/1956"), NumberOfPages = 296},
                new Book{Title="Trans-Atlantyk ", AuthorId = authors.Single(x => x.LastName == "Gombrowicz").Id, PublcationDate=DateTime.Parse("01/01/1988"),
                Description="Jedyny w swoim rodzaju utwór-wyzwanie, utwór-prowokacja, kapitalna rozprawa Gombrowicza z polskością, z podtrzymywanymi przez tradycję stereotypami narodowymi. Genialny humor i cudowny język, zadziwiające wykorzystanie przez pisarza form gawędy szlacheckiej, nie milknące pytania, które w każdym pokoleniu powinniśmy sobie zadawać"},
                new Book{Title="Barbarzyńca w ogrodzie ", AuthorId = authors.Single(x => x.LastName == "Herbert").Id, PublcationDate=DateTime.Parse("01/01/1962"), NumberOfPages = 223  ,
                Description="Czym jest ta książka? Zbiorem szkiców. Sprawozdaniem z podróży. Pierwsza podróż realna po miastach, muzeach i ruinach. Druga poprzez książki dotyczące widzianych miejsc. Te dwa widzenia, czy dwie metody, przeplatają się ze sobą."},
                new Book{Title="Martwa natura z wędzidłem ", AuthorId = authors.Single(x => x.LastName == "Herbert").Id, PublcationDate=DateTime.Parse("01/01/1993"), NumberOfPages = 150  ,
                Description="„Martwa natura z wędzidłem”, ostatni tom szkiców, który ukazał się za życia autora, wraz z „Labiryntem nad morzem” i „Barbarzyńcą w ogrodzie” tworzy trylogię - niezwykłą opowieść o „złotych wiekach” sztuki i cywilizacji europejskiej."},
                new Book{Title="Cesarz ", AuthorId = authors.Single(x => x.LastName == "Kapuściński").Id, PublcationDate=DateTime.Parse("01/01/1980"), NumberOfPages = 172  ,
                Description=@"Jeden z największych bestsellerów światowych. Przedmiotem reportażu-powieści są ludzie dworu cesarza Etiopii Hajle Sellasje zmarłego w 1975 roku. Ukazując ich służalczość, lizusostwo, strach, pazerność, uległość oraz walkę o względy władcy, Kapusciński w mistrzowski sposób przedstawia ponure kulisy jego panowania. Książka ma uniwersalny charakter, obnaża mechanizmy władzy nie tylko politycznej. Cesarzem Ryszard Kapuściński rozpoczął karierę międzynarodowa i nadał reportażowi wymiar literacki.\n"
                + @"\n"
                + @"23 stycznia 2017 roku minie 10. rocznica śmierci Ryszarda Kapuścińskiego, wybitnego pisarza, reportażysty o światowej sławie, poety i publicysty.\n"
                + @"\n"
                + @"„Czytelnik”, będący od kilkudziesięciu lat wydawcą książek Ryszarda Kapuścińskiego, wznawia z tej okazji wybór jego najważniejszych i cieszących się niesłabnącym zainteresowaniem dzieł: Cesarz, Heban, Imperium, Podróże z Herodotem, Szachinszach."},
                new Book{Title="Heban", AuthorId = authors.Single(x => x.LastName == "Kapuściński").Id, PublcationDate=DateTime.Parse("01/01/2002"), NumberOfPages = 344  ,
                Description=@"Heban to złożona z wielu wątków fascynująca, nowoczesna powieść-relacja z „ekspedycji” w głąb Czarnego Kontynentu, ukazująca Afrykę u progu XXI wieku, Afrykę rozdzieraną wojnami, głodem, epidemiami i korupcją.\n"
                + @"[...]„Heban” Ryszarda Kapuścińskiego to dramatycznie stawiane pytanie do nas, Europejczyków: czy z takim zapomnianym, umierającym kontynentem będziemy mogli spokojnie żyć?\n"
                + @"\n"
                + @"23 stycznia 2017 roku minie 10.rocznica śmierci Ryszarda Kapuścińskiego, wybitnego pisarza, reportażysty o światowej sławie, poety i publicysty.\n"
                + @"\n"
                + @"„Czytelnik”, będący od kilkudziesięciu lat wydawcą książek Ryszarda Kapuścińskiego, wznawia z tej okazji wybór jego najważniejszych i cieszących się niesłabnącym zainteresowaniem dzieł: Cesarz, Heban, Imperium, Podróże z Herodotem, Szachinszach."},
                new Book{Title="Imperium ", AuthorId = authors.Single(x => x.LastName == "Kapuściński").Id, PublcationDate=DateTime.Parse("01/01/1993"), NumberOfPages = 364  ,
                Description=@"Bestseller 1993 roku, tłumaczony na całym świecie. Imperium to bodaj najwybitniejsze dokonanie indywidualnego, pełnego inwencji stylu reportażu Kapuścińskiego, będącego niedościgłym wzorem dla największych dziennikarzy dzisiejszych czasów; ukazuje uchwycony na gorąco, w pełnych wielorakich znaczeń przybliżeniach, proces rozpadu Związku Radzieckiego – ostatniego imperium kończącego się stulecia.\n"
                + @"\n"
                + @"23 stycznia 2017 roku minie 10. rocznica śmierci Ryszarda Kapuścińskiego, wybitnego pisarza, reportażysty o światowej sławie, poety i publicysty.\n"
                + @"\n"
                + @"„Czytelnik”, będący od kilkudziesięciu lat wydawcą książek Ryszarda Kapuścińskiego, wznawia z tej okazji wybór jego najważniejszych i cieszących się niesłabnącym zainteresowaniem dzieł: Cesarz, Heban, Imperium, Podróże z Herodotem, Szachinszach. "},
                new Book{Title="Podróże z Herodotem ", AuthorId = authors.Single(x => x.LastName == "Kapuściński").Id, PublcationDate=DateTime.Parse("10/08/2008"), NumberOfPages = 284 ,
                Description="Ryszard Kapuściński wysoko cenił dzieło Herodota i to właśnie on zauważył, że " + "[...]zawsze mówi się o nim jako o historyku, o tym, czy było dokładnie tak, jak on pisał, czy może inaczej. Nikt nie zwrócił jednak uwagi, że Herodot był przede wszystkim pierwszym, wspaniałym reporterem...." + "Podróże z Herodotem są pochwałą Ryszarda Kapuścińskiego dla zasług starożytnego historyka i podróżnika, ale też autoportretem samego autora Szachinszacha, ogarniętego pasją podróżowania i poznawania świata."},
                new Book{Title="Szachinszach", AuthorId = authors.Single(x => x.LastName == "Kapuściński").Id, PublcationDate=DateTime.Parse("01/01/1982"), NumberOfPages = 176  ,
                Description=@"Obraz panowania i upadku szacha Iranu Mohammeda Rezy Pahlaviego. Fascynujący reportaż ukazuje kluczowy konflikt końca XX wieku między odgórną rewolucją, usiłującą wprowadzić „nowoczesność”, a kontrrewolucją fanatycznego integryzmu muzułmańskiego ajatollaha Chomeiniego.\n"
                + @"\n"
                + @"23 stycznia 2017 roku minie 10. rocznica śmierci Ryszarda Kapuścińskiego, wybitnego pisarza, reportażysty o światowej sławie, poety i publicysty."},
                new Book{Title="Wojna futbolowa ", AuthorId = authors.Single(x => x.LastName == "Kapuściński").Id, PublcationDate=DateTime.Parse("01/01/1986"), NumberOfPages = 205  ,
                Description=@"Jedna z książek Ryszarda Kapuścińskiego, polskiego korespondenta prasowego w Afryce i Ameryce Łacińskiej w latach 60. XX w. Wydana w 1978 roku.\n"
                + @"\n"
                + @"W książce zawarte są liczne historie z życia dziennikarza podróżującego po najbardziej niebezpiecznych miejscach w Afryce i Ameryce Łacińskiej. Z lektury możemy dowiedzieć się o wielu faktach i wydarzeniach w takich krajach jak m.in. Kongo, Kenia, Nigeria.\n"
                + @"\n"
                + @"Tytułowa wojna futbolowa wybucha pomiędzy Hondurasem a Salwadorem pośrednio w wyniku meczu piłkarskiego pomiędzy reprezentacjami piłkarskimi obu krajów."},
                new Book{Title="Treny", AuthorId = authors.Single(x => x.LastName == "Kochanowski").Id, PublcationDate=DateTime.Parse("01/01/1948"), NumberOfPages = 258  ,
                Description="Treny Jana Kochanowskiego - wyjątkowy w polskiej literaturze cykl utworów napisanych po śmierci zmarłej córki poety – Urszuli."},
                new Book{Title="Mendel Gdański", AuthorId = authors.Single(x => x.LastName == "Konopnicka").Id, NumberOfPages = 36  ,
                Description="Stary i ubogi Żyd Mendel od 27 lat mieszka w Warszawie. Zżył się z tym miastem, ma dobre kontakty z sąsiadami. Pewnego dnia słyszy od jednego z nich, że mają bić wszystkich Żydów tylko za to, że są Żydami. Mendel nie może zrozumieć czemu mieliby to robić. Postanawia nie uciekać i nie wypierać się swojego pochodzenia z nadzieją, że uda mu się przemówić do rozsądku ludziom..."},
                new Book{Title="Nasza szkapa ", AuthorId = authors.Single(x => x.LastName == "Konopnicka").Id, PublcationDate=DateTime.Parse("26/03/1900"), NumberOfPages = 40 },
                new Book{Title="Zdążyć przed Panem Bogiem", AuthorId = authors.Single(x => x.LastName == "Krall").Id, PublcationDate=DateTime.Parse("01/07/1979"), NumberOfPages = 125  ,
                Description=@"Kanoniczna książka, najsłynniejsza, obowiązkowa.\n"
                + @"Literacki dokument o wyścigu ze śmiercią.\n"
                + @"\n"
                + @"Od ponad czterdziestu lat Zdążyć przed Panem Bogiem pozostaje klasykiem polskiego reportażu i jedną z najbardziej przejmujących opowieści o powstaniu w getcie warszawskim w kwietniu 1943 roku i losach polskich Żydów, jakie stworzyła literatura XX wieku.\n"
                + @"\n"
                + @"To książka, która powstała z rozmów z Markiem Edelmanem, lekarzem, podczas wojny jednym z przywódców powstania.\n"
                + @"\n"
                + @"Marek Edelman opowiada o wojnie i o medycynie. O tym, czym jest godna śmierć i godne życie. Jest to także opowieść o ludziach, którzy mu towarzyszyli – o powstańcach, zakonnicach, dawnych akowcach, kobietach, które kochał, o pacjentach i o lekarzach.\n"
                + @"\n"
                + @"\n"
                + @"„ - Pan Bóg już chce zgasić świeczkę, a ja muszę szybko osłonić płomień, wykorzystując Jego chwilową nieuwagę. Niech się pali choć trochę dłużej, niż On by sobie życzył. To jest ważne: On nie jest za bardzo sprawiedliwy. To jest również przyjemne, bo jeżeli się coś uda – to bądź co bądź Jego wywiodło się w pole…\n"
                + @"\n"
                + @"– Wyścig z Panem Bogiem? Cóż to za pycha!\n"
                + @"\n"
                + @"– Wiesz, kiedy człowiek odprowadza innych ludzi do wagonów, to może mieć z Nim później parę spraw do załatwienia.A wszyscy przechodzili koło mnie, bo stałem przy bramie od pierwszego do ostatniego dnia. Wszyscy, czterysta tysięcy ludzi przeszło koło mnie”. (fragment książki)\n"
                + @"\n"
                + @"\n"
                + @"Na okładce najnowszego wydania znajduje się unikatowe zdjęcie Marka Edelmana w klinice profesora Jana Molla, jednego z twórców polskiej kardiochirurgii.Profesor Moll, z którym doktor Edelman współpracował, jest także jednym z bohaterów książki. "},
                new Book{Title="Nie-Boska komedia ", AuthorId = authors.Single(x => x.LastName == "Krasiński").Id, PublcationDate=DateTime.Parse("01/01/1948"), NumberOfPages = 150  ,
                Description="Jeden z najwybitniejszych utworów polskiego romantyzmu. Bohater Nie-boskiej komedii, hrabia Henryk, ponosi klęskę w życiu osobistym, gdyż uwiedziony pokusami fałszywej poezji , staje się przyczyną nieszczęść, które spadają na jego żonę i syna. W walce starego i nowego świata hrabia staje na czele obozu arystokracji przeciw zbuntowanym masom. Głęboko przeżywa jednak tragiczny konflikt historii. Jak prawdziwy bohater romantyczny - cierpi, buntuje się, szuka sensu życia."},
                new Book{Title="Solaris ", AuthorId = authors.Single(x => x.LastName == "Lem").Id, PublcationDate=DateTime.Parse("01/01/1961"), NumberOfPages = 340  ,
                Description=@"Najsłynniejsza powieść Stanisława Lema w nowym wydaniu! Dzieło przetłumaczone na kilkadziesiąt języków i dwukrotnie przeniesione na ekran.\n"
                + @"\n"
                + @"W Solaris Stanisław Lem podejmuje jeden z najpopularniejszych tematów literatury fantastycznej - temat Kontaktu. Z obcą cywilizacją, odmienną formą życia, a może po prostu z Nieznanym, tego Lem jednoznacznie nie dopowiada. Być może dlatego Solaris po kilkudziesięciu lat od pierwszego wydania wciąż fascynuje."},
                new Book{Title="Przygody Sindbada Żeglarza", AuthorId = authors.Single(x => x.LastName == "Leśmian").Id, PublcationDate=DateTime.Parse("01/01/1957"), NumberOfPages = 190  ,
                Description="Znany wątek z „Księgi tysiąca i jednej nocy” o przygodach Sindbada Żeglarza w adaptacji znanego polskiego poety i pisarza Bolesława Leśmiana."},
                new Book{Title="Dziady ", AuthorId = authors.Single(x => x.LastName == "Mickiewicz").Id, PublcationDate=DateTime.Parse("01/01/1900"), NumberOfPages = 304  ,
                Description=@"Dziady Adama Mickiewicza to jeden z najbardziej znanych utworów w literaturze polskiej i jednocześnie jedno z dzieł najbardziej reprezentatywnych dla polskiego romantyzmu. Od lat regularnie wystawiane na deskach teatrów całej Polski, czytane przez kolejne pokolenia czytelników, inspirujące twórców i niosące wciąż aktualne treści. Każda z części utworu porusza inne tematy, ale razem tworzą spójną wizję świata rządzonego przez niezmienne prawa boskiej sprawiedliwości i miłosierdzia.\n"
                + @"\n"
                 + @"Wydanie w serii Kolorowa Klasyka przygotowano ze szczególną dbałością o estetykę - kanoniczne XIX-wieczne ilustracje podkreślają atmosferę utworu, a doskonała okładka autorstwa znanego grafika Roberta Konrada przyciągnie oko każdego czytelnika."},
                new Book{Title="Pan Tadeusz", AuthorId = authors.Single(x => x.LastName == "Mickiewicz").Id, PublcationDate=DateTime.Parse("01/01/1946"), NumberOfPages = 296 },
                new Book{Title="Konrad Wallenrod", AuthorId = authors.Single(x => x.LastName == "Mickiewicz").Id, PublcationDate=DateTime.Parse("01/01/1943"), NumberOfPages = 88  ,
                Description="Średniowieczna Litwa jest zagrożona inwazją Krzyżaków, którzy dążą do jej zniewolenia i obrócenia Litwinów w niewolników. Tymczasem w samym zakonie wychowuje się przyszły mściciel, który doprowadzi najeźdźców do zguby. Nad jego życiem czuwa Halban - litewski wajdelota - śpiewak, poeta. Pozostający pod jego wpływem młody Alf najpierw ucieknie od swoich prześladowców, a potem porzuci piękną żonę i zrezygnuje z osobistego szczęścia, aby powrócić do Zakonu jako Konrad Wallenrod i mścić się za krzywdy własnego narodu."},
                new Book{Title="Dolina Issy ", AuthorId = authors.Single(x => x.LastName == "Miłosz").Id, NumberOfPages = 276 ,
                Description=@"Jedna z najwspanialszych powieści o dzieciństwie i dojrzewaniu autorstwa laureata Literackiej Nagrody Nobla. Książka napisana przez Miłosza na emigracji i wydana po raz pierwszy w Paryżu w roku 1955 ukazuje pasje młodego bohatera, Tomasza, zdobywającego samotnie wiedzę o świecie.\n"
                + @"Utwór Miłosza nie ma typowej, wyrazistej fabuły. Akcja powieści toczy się głównie na Litwie w dolinie zmitologizowanej rzeki Issy."},
                new Book{Title="Zniewolony umysł", AuthorId = authors.Single(x => x.LastName == "Miłosz").Id, PublcationDate=DateTime.Parse("01/01/1989"), NumberOfPages = 282,
                Description="Dzieło Czesława Miłosza to nie tylko znakomita rozprawa z dziedziny politologii i badań nad komunizmem, to literacki traktat albo swoista powieść z kluczem, zawierająca ponadczasową refleksję o kondycji ludzkiej, etyce, wolności i zniewoleniu, wyrastająca jednak z konkretnego i przez to wiarygodnego doświadczenia świadka i uczestnika. Edycja niniejsza jest przedsięwzięciem wyjątkowym: wydawcy udało się namówić autora do skomentowania utworu, do ponownego spojrzenia na wypadki sprzed półwiecza i podzielenia się refleksjami z czytelnikiem."},
                new Book{Title="Tango ", AuthorId = authors.Single(x => x.LastName == "Mrożek").Id, PublcationDate=DateTime.Parse("25/09/2014"), NumberOfPages = 208 ,
                Description=@"Wydając Tango w nowej szacie graficznej chcieliśmy przypomnieć, że ten dramat to nie tylko bardziej lub mniej lubiana lektura szkolna, ale najbardziej znany i najważniejszy utwór Sławomira Mrożka o społecznych zagrożeniach. Warto go poznać, warto do niego wracać – mamy nadzieję, że to nowe wydanie będzie do tego zachęcać.\n"
                + @"W 2009 r. w Teatrze Narodowym Jerzy Jarocki po raz kolejny wystawił Tango. Okazało się, że choć od napisania tego tekstu minęło ponad 40 lat, wciąż mówi on o nas."},
                new Book{Title="Emigranci", AuthorId = authors.Single(x => x.LastName == "Mrożek").Id, PublcationDate=DateTime.Parse("01/01/1996"), NumberOfPages = 187 ,
                Description="Emigranci (1974) to najwybitniejszy utwór Sławomira Mrożka od ukazania się Tanga, a zarazem jeden z najważniejszych polskich dramatów okresu powojennego. Dwaj cudzoziemcy z bliżej nieokreślonego kraju zamieszkują wspólnie suterenę w nieznanym mieście Europy Zachodniej. Wyobcowany intelektualista, AA, wybrał emigrację z powodów politycznych, jego towarzysz zaś, chłoporobotnik XX, wyjechał wyłącznie dla zarobku. Skazani są na własne towarzystwo, a ich symbioza polega na wzajemnym uzależnieniu: XX wykorzystuje AA materialnie, ten natomiast twierdzi, że wykorzystuje towarzysza pod kątem studiów nad niewolniczą mentalnością swych rodaków. AA, sam sfrustrowany i bezwolny, z wyższością odnosi się do przedstawiciela niższej klasy, dorobkiewicza, którego jedynym celem w życiu jest poprawa własnego bytu. W tych warunkach obustronne konflikty i antagonizmy nabierają wyjątkowej ostrości. W szerszym ujęciu konfrontacja pomiędzy AA i XX dotyka jednego z ważniejszych problemów w Polsce powojennej - rozdźwięku między inteligencją i robotnikami. W finale dokonuje się synteza wartości obu grup społecznych, zwiastująca przełamanie powstałych barier."},
                new Book{Title="Wybór poezji", AuthorId = authors.Single(x => x.LastName == "Morsztyn").Id, PublcationDate=DateTime.Parse("01/01/1988") },
                new Book{Title="Opium w rosole", AuthorId = authors.Single(x => x.LastName == "Musierowicz").Id, PublcationDate=DateTime.Parse("01/01/1986"), NumberOfPages = 236  ,
                Description="        "},
                new Book{Title="Vade-mecum", AuthorId = authors.Single(x => x.LastName == "Norwid").Id, PublcationDate=DateTime.Parse("01/01/1962"), NumberOfPages = 208 ,
                Description="Słynny zbiór wierszy \"Późnego romantyka\"."},
                new Book{Title="Poezje          ", AuthorId = authors.Single(x => x.LastName == "Norwid").Id, PublcationDate=DateTime.Parse("01/01/1956"), NumberOfPages = 404 ,
                Description="Cyprian Kamil Norwid uznawany jest za jednego z najzdolniejszych polskich artystów - poeta, prozaik, malarz, dramatopisarz i filozof. Twórczość Norwida, trudna do zrozumienia dla jemu współczesnych, po jego śmierci została zapomniana. W okresie Młodej Polski, głównie za sprawą Zenona Przesmyckiego, został odkryty na nowo"},
                new Book{Title="Nad Niemnem", AuthorId = authors.Single(x => x.LastName == "Orzeszkowa").Id, PublcationDate=DateTime.Parse("01/01/1954"),
                Description="Nad Niemnem jest epopeją pozytywistyczną ukazującą obraz polskiego społeczeństwa drugiej połowy XIX wieku. Powieść Elizy Orzeszkowej wpisała się do kanonu literatury polskiej. Tłem powieści jest świat polskich dworów i zaścianków szlacheckich na Litwie. Autorka wprowadza nas w rytm, obyczaje i piękno tego świata, opisując losy ubogiej szlachcianki Justyny Orzelskiej i miłości, jaka połączyła ją z żyjącym z pracy własnych rąk Janem Bohatyrowiczem. Wątek mezaliansu, nawiązujący do staropolskiej legendy o Janie i Cecylii, a zapowiadający pogodzenie się zaścianka z dworem, jest ważnym motywem powieści. W Nad Niemnem obecne są także wspomnienie powstania styczniowego i refleksja nad ideą odrodzenia narodu polskiego. Powieść Elizy Orzeszkowej była kilkakrotnie ekranizowana w kinie i telewizji."},
                new Book{Title="Lalka", AuthorId = authors.Single(x => x.LastName == "Prus").Id, PublcationDate=DateTime.Parse("01/01/1949"), NumberOfPages = 664},
                new Book{Title="Kamizelka", AuthorId = authors.Single(x => x.LastName == "Prus").Id, PublcationDate=DateTime.Parse("01/01/1952"), NumberOfPages = 24 ,
                Description="Co zrobić gdy ma umrzeć ukochana osoba. Okłamywać ją czy jej o tym powiedzieć. Żadne rozwiązanie nie będzie idealne, ale na coś trzeba się zdecydować. Krótka nowela mówi nam o sile uczuć i o nieuchronności losu."},
                new Book{Title="Faraon", AuthorId = authors.Single(x => x.LastName == "Prus").Id, PublcationDate=DateTime.Parse("01/01/1949"), NumberOfPages = 400  ,
                Description="Powieść historyczna Bolesława Prusa, której akcja rozgrywa się w starożytnym Egipcie. Bohaterem książki jest młody faraon, Ramzes XIII, próbujący poznać mechanizmy rządzenia państwem i podejmującego walkę o niezależność władzy faraona od kasty kapłańskiej."},
                new Book{Title="Chłopi", AuthorId = authors.Single(x => x.LastName == "Reymont").Id, PublcationDate=DateTime.Parse("01/01/1952"), NumberOfPages = 640  ,
                Description="Powieść Władysława Reymonta pisana w latach 1901–1908, a wyróżniona Nagrodą Nobla w roku 1924, ukazująca życie chłopa na wsi końca XIX wieku. Akcja utworu toczy się we wsi Lipce, a wyznaczają ją cztery pór roku wraz z przypisanymi do nich obyczajami, świętami kościelnymi i pracami rolnymi. Na tym tle rozgrywają się losy rodziny Borynów i młodej dziewczyny Jagny."},
                new Book{Title="Ziemia obiecana", AuthorId = authors.Single(x => x.LastName == "Reymont").Id, PublcationDate=DateTime.Parse("01/01/1956"), NumberOfPages = 200  ,
                Description=@"Jedna z najlepszych polskich powieści!\n"
                + @"Łódź, lata osiemdziesiąte XIX wieku. Trzej przyjaciele – polski szlachcic Karol Borowiecki, Maks Baum, syn niemieckiego fabrykanta, oraz Żyd, Moryc Welt – próbują odnieść sukces w świecie rozkwitających jak ryby po deszczu, fabryk. Każdym z nich kierują inne pobudki, każdy kieruje się innymi wartościami. Czy ich życiowe wybory okażą się trafne? Reymont w Ziemi obiecanej kreśli wielowymiarową panoramę przemysłowego miasta, jakim w drugiej połowie XIX wieku była dynamicznie rozwijająca się Łódź. Przesycona autentyzmem atmosfera, drapieżna codzienność, barwne tło obyczajowe – oto atuty tej powieści"},
                new Book{Title="W pustyni i w puszczy", AuthorId = authors.Single(x => x.LastName == "Sienkiewicz").Id, PublcationDate=DateTime.Parse("16/10/1911"), NumberOfPages = 352  ,
                Description=@"Kolekcja dzieł wybitnego polskiego pisarza Henryka Sienkiewicza – klasyka literatury i mistrza plastycznych opisów, który zdobył w 1905 roku literacką Nagrodę Nobla za całokształt swojej twórczości.\n"
                + @"Palące słońce pustyni, egzotyczne piękno buszu, starożytne egipskie miasta, zwyczaje dzikich plemion Afryki – to tło pasjonującej powieści przygodowej, która od ponad 100 lat cieszy się niesłabnącym powodzeniem, zwłaszcza wśród młodzieży.\n"
                + @"W pustyni i w puszczy przetłumaczono na wiele języków, a dwie ekranizacje powieści stały się kinowymi hitami.\n"
                + @"\n"
                + @"Koniec XIX wieku. W Sudanie trwa powstanie Mahdiego przeciw Egiptowi i Wielkiej Brytanii. Jego zwolennicy porywają dzieci inżynierów budujących Kanał Sueski – Angielkę Nel Rawlison i Polaka Stasia Tarkowskiego. Chcą wymienić ich na swoich bliskich, których aresztowano. Ta dwójka zostaje zmuszona do długiej i wyczerpującej podróży wzdłuż Nilu i przez Saharę. Udaje się im wprawdzie uwolnić, jednak to nie koniec ich kłopotów. Muszą uciekać jak najdalej od swoich prześladowców, a jedyna droga wiedzie w głąb dzikiej, pełnej drapieżników, afrykańskiej dżungli.Nie unikną też spotkań z groźnymi murzyńskimi plemionami."},
                new Book{Title="Quo vadis", AuthorId = authors.Single(x => x.LastName == "Sienkiewicz").Id, PublcationDate=DateTime.Parse("01/01/1954"), NumberOfPages = 448},
                new Book{Title="Potop", AuthorId = authors.Single(x => x.LastName == "Sienkiewicz").Id, PublcationDate=DateTime.Parse("01/01/1948"), NumberOfPages = 783  ,
                Description=@"„Potop”, druga z powieści tworzących „Trylogię”, przedstawia dzieje Polski w dobie najazdu Szwedów (1655-1660). Zasadniczą ideą powieści jest problem zdrady i wierności, będący kryterium moralnej oceny zarówno postaci historycznych (np. Radziwiłł), jak i fikcyjnych (przede wszystkim Kmicic).\n"
                +@"\n"
                + @"Z głównym motywem wiąże się sposób prezentacji zdarzeń - Sienkiewicz ukazuje dwie fazy konfliktu polsko-szwedzkiego, w którym dużą rolę odegrała zdrada magnatów i części szlachty. Początkowy obraz wrogiego „potopu” przynosi bliskość całkowitej klęski Rzeczypospolitej, w której tylko nieliczni obywatele zdolni są do obrony jej suwerenności."},
                new Book{Title="Balladyna", AuthorId = authors.Single(x => x.LastName == "Słowacki").Id, PublcationDate=DateTime.Parse("01/01/1959"), NumberOfPages = 180  ,
                Description="Jeden z najbardziej znanych dramatów Juliusza Słowackiego - opowieść o dwóch siostrach, Alinie i Balladynie, które, by rozstrzygnąć spór o rękę księcia Kirkora postanawiają nazbierać w lesie malin. Jedno z najpopularniejszych wydań z opracowanej, ponadto napisane czcionką, ułatwiającą szybie czytanie."},
                new Book{Title="Kordian", AuthorId = authors.Single(x => x.LastName == "Słowacki").Id, PublcationDate=DateTime.Parse("01/01/1967"), NumberOfPages = 128  ,
                Description="Polska pod jarzmem cara - zbrodniarza. Patrioci planują na niego zamach. Jeden z nich, tajemniczy młodzieniec w masce, podejmuje się zabić znienawidzonego tyrana. Wpisuje się tym samym w krąg działań, które zaplanował szatan u progu kolejnego stulecia. Czy mu się powiedzie? Czy ma na tyle odwagi, by działać na rzecz własnego, zniewolonego i upokorzonego narodu? A może Kordian, bo o nim tu mowa, jest zbyt słaby?..."},
                new Book{Title="Chwila", AuthorId = authors.Single(x => x.LastName == "Szymborska").Id, PublcationDate=DateTime.Parse("01/01/2002"), NumberOfPages = 48  ,
                Description="Każdy z utworów zgromadzonych w tomie \"Chwila\" to krystalicznie czysty, precyzyjny i zwarty minitraktat: filozoficzny, metafizyczny, egzystencjalny. Szymborska mówi o sprawach najważniejszych w sposób skłaniający do odkrywczych medytacji i przemyśleń.\n"
                + @"Edycja specjalna tomu ilustrowana jest skanami rękopisów i maszynopisów poetki."},
                new Book{Title="Lokomotywa", AuthorId = authors.Single(x => x.LastName == "Tuwim").Id, PublcationDate=DateTime.Parse("01/01/1958"), NumberOfPages = 56  ,
                Description=@"„Lokomotywę”, „Rzepkę” i „Ptasie radio” autorstwa Juliana Tuwima znają wszyscy Polacy. W serii Muzeum Książki Dziecięcej poleca prezentujemy mocno już zapomniane wydanie z 1958 roku w opracowaniu graficznym jednego z twórców polskiej szkoły plakatu, Jana Lenicy.\n"
                + @"\n"
                + @"Na stronie tytułowej znajdziemy jeden z najzabawniejszych portretów autora, któremu kanarek przysiadł na piórze. Lokomotywa jest wielka i ciężka, mknie przez nowoczesny świat. Scena, w której rzepka wyskakuje z ziemi, jest dynamiczna i wesoła. Córka Juliana Tuwima, Ewa Tuwim-Woźniak, ilustracje mistrza Jana Lenicy stawia na równi z najbardziej rozpoznawalnymi obrazkami Marcina Szancera.\n"
                + @"\n"
                + @"Warto sięgnąć po to konkretnie wydanie, odwołać się do wspomnień, a jednocześnie pokazać dzisiejszym małym czytelnikom przykład doskonałego opracowania edytorskiego. "},
                new Book{Title="Słoń Trąbalski", AuthorId = authors.Single(x => x.LastName == "Tuwim").Id, PublcationDate=DateTime.Parse("01/01/1965"), NumberOfPages = 56  ,
                Description=@"Ilustracje Ignacego Witza do „Słonia Trąbalskiego” Juliana Tuwima znają chyba wszyscy dorośli. Ale czy wiecie, że ta ponadczasowa książka powstała w 1948 roku, gdy obaj artyści mieszkali w słynnym Domu Czytelnika?\n"
                + @"\n"
                + @"Doskonałe wiersze należą do kanonu polskiej poezji dziecięcej.Nikomu nie trzeba zachwalać tytułowego Słonia Trąbalskiego, Abecadła czy O Grzesiu kłamczuchu i jego cioci.\n"
                + @"\n"
                + @"Prawdziwą edytorską ciekawostką jest to, że pierwotnie książka była zaplanowana w poziomym formacie, ilustracje przeszły ewolucję kolorystyczną, było ich też więcej!Dodruki „Słonia Trąbalskiego” ukazywały się niemal co roku, w twardej lub miękkiej oprawie przez wiele, wiele lat.Książka ukazuje się w serii Muzeum Książki Dziecięcej poleca.Warto sięgnąć po to konkretnie wydanie, odwołać się do wspomnień, a jednocześnie pokazać dzisiejszym małym czytelnikom przykład doskonałego opracowania edytorskiego, które było możliwe dzięki przyjaźni."},
                new Book{Title="Szewcy", AuthorId = authors.Single(x => x.LastName == "Witkiewicz").Id, PublcationDate=DateTime.Parse("01/01/1992"), NumberOfPages = 98  ,
                Description="W utworze Witkacy przedstawił obraz przyszłego społeczeństwa, ukazując również swoje katastroficzne przeczucia na jego temat. Dramat zamyka w sobie namiastkę wyobrażenia pisarza o mechanizacji społeczeństwa i następnie upadku cywilizacji, stanowi krytykę rewolucji, kapitalizmu, komunizmu i faszyzmu."},
                new Book{Title="Wesele", AuthorId = authors.Single(x => x.LastName == "Wyspiański").Id, PublcationDate=DateTime.Parse("01/01/1960"), NumberOfPages = 258},
                new Book{Title="Przedwiośnie", AuthorId = authors.Single(x => x.LastName == "Żeromski").Id, PublcationDate=DateTime.Parse("01/01/1953"), NumberOfPages = 304 ,
                Description="Książka zawiera: starannie przygotowany tekst utworu, opatrzony na marginesach ojaśnieniami i komentarzami (oznaczony symbolami garficznymi), życiorys autora, streszczenie lektury, dokładne omówienie."},
                new Book{Title="Ludzie bezdomni", AuthorId = authors.Single(x => x.LastName == "Żeromski").Id, PublcationDate=DateTime.Parse("01/01/1954"), NumberOfPages = 352  ,
                Description="Ludzie bezdomni to opowieść o losach lekarza – Tomasza Judyma – wywodzącego się z nizin społecznych, który dzięki ciężkiej pracy i uporowi zdobył wykształcenie i zaangażował się w pomoc ubogim. Droga, którą obrał okazała się niezwykle trudna, gdyż jego bezinteresowna pomoc ludziom ubogim prowadziła do konfliktów z kolegami po fachu. Czy uda mu się zrealizować obrany cel i osiągnąć szczęście? Na drodze Judyma pojawia się Joasia Podborska – uboga szlachcianka, która ze względu na trudną sytuację materialną zostaje zmuszona do tułaczki po domach zamożnych ludzi i pracy w charakterze nauczycielki. Kobieta pragnie jednak czegoś więcej niż pomagać ludziom – marzy o założeniu z Tomaszem rodziny i stworzeniu własnego domu. Czy lekarz pochłonięty pracą na rzecz ubogich znajdzie czas na miłość i życie u boku Joasi?"},
                new Book{Title="Syzyfowe prace", AuthorId = authors.Single(x => x.LastName == "Żeromski").Id, NumberOfPages = 176  ,
                Description=@"Powieść Stefana Żeromskiego, która po raz pierwszy ukazała się w dzienniku „Nowa Reforma” od 7 lipca do 24 września 1897.\n"
                + @"\n"
                + @"W Syzyfowych pracach autor na podstawie własnych doświadczeń z dzieciństwa i lat młodzieńczych przedstawił obraz szkoły w rosyjskim Królestwie Polskim i walkę polskiej młodzieży z rusyfikacją.\n"
                + @"\n"
                + @"Stefan Żeromski pod przejrzystymi kryptonimami ukrył szkołę w Pińczowie jako progimnazjum w Pyrzogłowach i gimnazjum kieleckie jako szkoła w Klerykowie. Pod osobą Andrzeja Radka ukrył swego bliskiego przyjaciela Jana Wacława Machajskiego, syna mieszczanina pińczowskiego."},
                new Book{Title="Wierna rzeka", AuthorId = authors.Single(x => x.LastName == "Żeromski").Id, PublcationDate=DateTime.Parse("01/01/1962") ,
                Description="Nazywana jest najpiękniejszą opowieścią o roku 1863 w literaturze polskiej. Stanowi ostatnie ogniwo zamierzonego i tylko częściowo zrealizowanego przez Stefana Żeromskiego cyklu historycznego, zaczynającego się w Niezdołach, zapadłym dworku szlacheckim, gdzie na tle wydarzeń powstania styczniowego rozgrywają się losy tragicznej miłości ubogiej szlachcianki Salomei Brynickiej i uratowanego przez nią powstańca."},
            };

            foreach (Book book in books)
            {
                context.Books.Add(book);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
                new Category{Name = "Beletrystyka"},
                new Category{Name = "Literatura faktu, publicystyka"},
                new Category{Name = "Literatura popularnonaukowa"},
                new Category{Name = "Literatura dziecięca"},
                new Category{Name = "Komiksy"},
                new Category{Name = "Poezja, dramat, satyra"},
                new Category{Name = "Pozostałe"},
            };

            foreach (Category category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var subcategories = new Subcategory[]
            {
                new Subcategory{Name = "fantastyka, fantasy, science fiction"},
                new Subcategory{Name = "literatura obyczajowa, romans"},
                new Subcategory{Name = "horror"},
                new Subcategory{Name = "klasyka"},
                new Subcategory{Name = "kryminał, sensacja, thriller"},
                new Subcategory{Name = "literatura młodzieżowa"},
                new Subcategory{Name = "literatura piękna"},
                new Subcategory{Name = "powieść historyczna"},
                new Subcategory{Name = "powieść przygodowa"},
                new Subcategory{Name = "biografia, autobiografia, pamiętnik"},
                new Subcategory{Name = "literatura faktu"},
                new Subcategory{Name = "literatura podróżnicza"},
                new Subcategory{Name = "publicystyka literacka, eseje"},
                new Subcategory{Name = "astronomia, astrofizyka"},
                new Subcategory{Name = "biznes, finanse"},
                new Subcategory{Name = "encyklopedie, słowniki"},
                new Subcategory{Name = "ezoteryka, senniki, horoskopy"},
                new Subcategory{Name = "filozofia, etyka"},
                new Subcategory{Name = "flora i fauna"},
                new Subcategory{Name = "historia"},
                new Subcategory{Name = "informatyka, matematyka"},
                new Subcategory{Name = "językoznawstwo, nauka o literaturze"},
                new Subcategory{Name = "nauki przyrodnicze (fizyka, chemia, biologia, itd.)"},
                new Subcategory{Name = "nauki społeczne (psychologia, socjologia, itd.)"},
                new Subcategory{Name = "popularnonaukowa"},
                new Subcategory{Name = "poradniki"},
                new Subcategory{Name = "poradniki dla rodziców"},
                new Subcategory{Name = "technika"},
                new Subcategory{Name = "bajki"},
                new Subcategory{Name = "baśnie, legendy, podania"},
                new Subcategory{Name = "historie biblijne"},
                new Subcategory{Name = "interaktywne, obrazkowe, edukacyjne"},
                new Subcategory{Name = "literatura dziecięca"},
                new Subcategory{Name = "opowiadania, powieści"},
                new Subcategory{Name = "opowieści dla młodszych dzieci"},
                new Subcategory{Name = "popularnonaukowa dziecięca"},
                new Subcategory{Name = "pozostałe"},
                new Subcategory{Name = "wierszyki, piosenki"},
                new Subcategory{Name = "komiksy"},
                new Subcategory{Name = "poezja"},
                new Subcategory{Name = "satyra"},
                new Subcategory{Name = "utwór dramatyczny (dramat, komedia, tragedia)"},//
                new Subcategory{Name = "albumy"},
                new Subcategory{Name = "czasopisma"},
                new Subcategory{Name = "film, kino, telewizja"},
                new Subcategory{Name = "hobby"},
                new Subcategory{Name = "inne"},
                new Subcategory{Name = "kulinaria, przepisy kulinarne"},
                new Subcategory{Name = "militaria, wojskowość"},
                new Subcategory{Name = "motoryzacja"},
                new Subcategory{Name = "muzyka"},
                new Subcategory{Name = "religia"},
                new Subcategory{Name = "rękodzieło"},
                new Subcategory{Name = "rozrywka"},
                new Subcategory{Name = "sport"},
                new Subcategory{Name = "sztuka"},
                new Subcategory{Name = "teatr"},
                new Subcategory{Name = "turystyka, mapy, atlasy"},
                new Subcategory{Name = "zdrowie, medycyna"}
            };

            foreach (Subcategory subcategory in subcategories)
            {
                context.Subcategories.Add(subcategory);
            }
            context.SaveChanges();

            var shelves = new Shelf[]
            {
                new Shelf{Name = "Przeczytane"},
                new Shelf{Name = "Teraz czytam"},
                new Shelf{Name = "Chcę przeczytać"},
                new Shelf{Name = "Chcę w prezencie"},
                new Shelf{Name = "Posiadam"},
                new Shelf{Name = "Ulubione"}
            };

            foreach (Shelf shelf in shelves)
            {
                context.Shelves.Add(shelf);
            }
            context.SaveChanges();

            var categorySubcategoryAssigments = new CategorySubcategoryAssigment[]
            {
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Beletrystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "fantastyka, fantasy, science fiction").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Beletrystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "literatura obyczajowa, romans").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Beletrystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "horror").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Beletrystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "klasyka").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Beletrystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "kryminał, sensacja, thriller").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Beletrystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "literatura młodzieżowa").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Beletrystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "literatura piękna").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Beletrystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "powieść przygodowa").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura faktu, publicystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "biografia, autobiografia, pamiętnik").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura faktu, publicystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "literatura faktu").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura faktu, publicystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "literatura podróżnicza").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura faktu, publicystyka").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "publicystyka literacka, eseje").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "astronomia, astrofizyka").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "biznes, finanse").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "encyklopedie, słowniki").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "ezoteryka, senniki, horoskopy").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "filozofia, etyka").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "flora i fauna").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "historia").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "informatyka, matematyka").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "językoznawstwo, nauka o literaturze").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "nauki przyrodnicze (fizyka, chemia, biologia, itd.)").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "nauki społeczne (psychologia, socjologia, itd.)").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "popularnonaukowa").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "poradniki").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "poradniki dla rodziców").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura popularnonaukowa").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "technika").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "bajki").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "baśnie, legendy, podania").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "historie biblijne").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "interaktywne, obrazkowe, edukacyjne").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "literatura dziecięca").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "opowiadania, powieści").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "opowieści dla młodszych dzieci").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "popularnonaukowa dziecięca").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "pozostałe").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Literatura dziecięca").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "wierszyki, piosenki").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Komiksy").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "komiksy").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Poezja, dramat, satyra").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "poezja").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Poezja, dramat, satyra").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "satyra").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Poezja, dramat, satyra").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "utwór dramatyczny (dramat, komedia, tragedia)").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "albumy").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "czasopisma").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "film, kino, telewizja").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "hobby").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "inne").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "kulinaria, przepisy kulinarne").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "militaria, wojskowość").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "motoryzacja").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "muzyka").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "religia").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "rękodzieło").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "rozrywka").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "sport").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "sztuka").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "teatr").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "turystyka, mapy, atlasy").Id},
                new CategorySubcategoryAssigment {CategoryId = categories.Single(x => x.Name == "Pozostałe").Id,
                    SubcategoryId= subcategories.Single(x => x.Name == "zdrowie, medycyna").Id},
            };

            foreach (CategorySubcategoryAssigment categorySubcategoryAssigment in categorySubcategoryAssigments)
            {
                context.CategorySubcategoryAssigments.Add(categorySubcategoryAssigment);
            }
            context.SaveChanges();
        }
    }
}
