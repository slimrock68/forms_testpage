@Section Scripts
<script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.0/jquery.validate.js">
</script>
<script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.0/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
End Section

@Code
    Dim submitMessage As String = ""
    Dim Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 As String
    Q1 = "1. Ilaah wuxuu joogaa"
    Q2 = "2. Maalintii afraad ee uumista Ilaah wuxuu abuuray"
    Q3 = "3. Ilaah wuxuu rabaa"
    Q4 = "4. Maalintii ugu dambaysay uumista, Ilaah"
    Q5 = "5. Ilaah wuxuu jecel yahay"
    Q6 = "6. Ilaah waa qoduus, taas aawadeed muxuu ciqaabi doonaa?"
    Q7 = "7. Bilowgii Ilaah muxuu abuuray?"
    Q8 = "8. Bal yaa weligiis jiray, weligiisna jiri doona?"
    Q9 = "9. Waxaa jira Ilaah keliya oo run ah."
    Q10 = "10. Ilaah wax kasta wuu og yahay."
    Validation.RequireField("tbName", "The name address field is required.")
    Validation.RequireField("tbEmail", "The email field is required.")

    If IsPost Then
        Dim strName As String = Request.Form("tbName")
        Dim strEmail As String = Request.Form("tbEmail")
        Dim strPhone As String = Request.Form("tbPhone")
        Dim strCity As String = Request.Form("tbCity")
        Dim strCountry As String = Request.Form("tbCountry")
        Dim strComment As String = Request.Form("tbComment")

        Dim strNow As DateTime = Now()
        Dim strNCemail As String = "noloshacusub@noloshacusub.net"
        Dim A1, A2, A3, A4, A5, A6, A7, A8, A9, A10 As String

        A1 = Request.Form("A1") 'RadioButtonList1.SelectedValue
        A2 = Request.Form("A2") 'RadioButtonList2.SelectedValue
        A3 = Request.Form("A3") 'RadioButtonList3.SelectedValue
        A4 = Request.Form("A4") 'RadioButtonList4.SelectedValue
        A5 = Request.Form("A5") 'RadioButtonList5.SelectedValue
        A6 = Request.Form("A6") 'TextBox6.Text
        A7 = Request.Form("A7") 'TextBox7.Text
        A8 = Request.Form("A8") 'TextBox8.Text
        A9 = Request.Form("A9") 'RadioButtonList9.SelectedValue
        A10 = Request.Form("A10") 'Radiobuttonlist10.SelectedValue

        Dim ContactID As Integer = 0
        Dim strContactCheck As String = "SELECT ID from Nolosha1.tblContactTest WHERE ContactEmail = '" & strEmail & "'"

        ContactID = DataTier.executeScalar(strContactCheck)

        'Dim CorrespondenceNumber As Integer = 1
        If ContactID = 0 Then
            submitMessage = "Thank you, " + strName + ". An email will be sent to " + strEmail + ". Submitted at " + strNow

            Dim strInsertContact As String = "INSERT INTO Nolosha1.tblContactTest " &
                                   "(ContactName, ContactEmail, ContactCountry, DateSubmitted, ContactComments) VALUES (" &
                                    "'" & strName & "', " &
                                    "'" & strEmail & "', " &
                                    "'" & strCity & "', " &
                                    "'" & strCountry & "', " &
                                    "'" & strNow & "', " &
                                    "'" & strComment & "')"
            DataTier.ExecuteSQL(strInsertContact)
        End If

        ContactID = DataTier.executeScalar(strContactCheck)


        Dim strInsertCorrespondence As String = "Insert Into Nolosha1.tblGradeTest (ContactID, TestID, UserComment, A01, A02, A03, A04, A05, A06, A07, A08, A09, A10, DateSubmitted) VALUES (" & ContactID & ", 1, '" & strComment & "', '" & A1 & "', '" & A2 & "', '" & A3 & "', '" & A4 & "', '" & A5 & "', '" & A6 & "', '" & A7 & "', '" & A8 & "', '" & A9 & "', '" & A10 & "', '" & strNow & "')"

        DataTier.ExecuteSQL(strInsertCorrespondence)

        If strEmail = "" Then strEmail = "noloshacusub@noloshacusub.info"

        Dim strBodyEmail As String

        strBodyEmail = "<u>Contact information</u>:<br />" &
                   strName &
                   "<br />" & strCity & ", " & strCountry &
                   "<br />" & strEmail & "<br /><br />" &
                   "<u>Comments:</u>" & strComment & "<br /><br />" &
                   "<u>Results</u>" &
                   "<br /><br /><i>" & Q1 & "</i><br />" & A1 &
                   "<br /><br /><i>" & Q2 & "</i><br />" & A2 &
                   "<br /><br /><i>" & Q3 & "</i><br />" & A3 &
                   "<br /><br /><i>" & Q4 & "</i><br />" & A4 &
                   "<br /><br /><i>" & Q5 & "</i><br />" & A5 &
                   "<br /><br /><i>" & Q6 & "</i><br />" & A6 &
                   "<br /><br /><i>" & Q7 & "</i><br />" & A7 &
                   "<br /><br /><i>" & Q8 & "</i><br />" & A8 &
                   "<br /><br /><i>" & Q9 & "</i><br />" & A9 &
                   "<br /><br /><i>" & Q10 & "</i><br />" & A10 &
                   "<br /><br /><font size='-1'><i>Submitted at " & strNow & ".</i></font>"

        'Dim strNCemail As String = "noloshacusub@noloshcusub.info"
        SendMail.SendMail(strNCemail, strEmail, strNCemail, "Jawaabaha IKJK 1", strBodyEmail)


    End If
End Code

<!DOCTYPE html>
<html >
<head>
  <!-- Site made with Mobirise Website Builder v4.8.1, https://mobirise.com -->
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="generator" content="Mobirise v4.8.1, mobirise.com">
  <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1">
  <link rel="shortcut icon" href="assets/images/transport-128x128.png" type="image/x-icon">
  <meta name="description" content="Website Builder Description">
  <title>Dersiga Kowaad</title>
  <link rel="stylesheet" href="assets/web/assets/mobirise-icons/mobirise-icons.css">
  <link rel="stylesheet" href="assets/tether/tether.min.css">
  <link rel="stylesheet" href="assets/soundcloud-plugin/style.css">
  <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
  <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-grid.min.css">
  <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-reboot.min.css">
  <link rel="stylesheet" href="assets/dropdown/css/style.css">
  <link rel="stylesheet" href="assets/animatecss/animate.min.css">
  <link rel="stylesheet" href="assets/theme/css/style.css">
  <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css">
  
</head>
<body>

<!-- Google Analytics -->
<!-- Global Site Tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-1577437-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-1577437-1');
</script>
<!-- /Google Analytics -->


  <section class="menu cid-qwrKBwiF8h" once="menu" id="menu1-59">

    <nav class="navbar navbar-expand beta-menu navbar-dropdown align-items-center navbar-fixed-top collapsed bg-color transparent">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <div class="hamburger">
                <span></span>
                <span></span>
                <span></span>
                <span></span>
            </div>
        </button>
        <div class="menu-logo">
            <div class="navbar-brand">
                
                <span class="navbar-caption-wrap"><a class="navbar-caption text-white display-4" href="index.html">
                        Nolosha Cusub</a></span>
            </div>
        </div>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav nav-dropdown nav-right" data-app-modern-menu="true"><li class="nav-item"><a class="nav-link link text-white tooltipstered display-4" href="literature_default.html" aria-expanded="false" data-toggle="tooltip" data-placement="bottom" title="Literature">Qoraal</a></li><li class="nav-item"><a class="nav-link link text-white tooltipstered display-4" href="audio_visual_default.html" aria-expanded="false" data-toggle="tooltip" data-placement="bottom" title="Audio/Visual">Maqal</a></li><li class="nav-item"><a class="nav-link link text-white tooltipstered display-4" href="bible_default.html" aria-expanded="false" data-toggle="tooltip" data-placement="bottom" title="The Holy Bible">Kitaaabka Quduuska Ah</a></li><li class="nav-item"><a class="nav-link link text-white tooltipstered display-4" href="links_default.html" aria-expanded="false" data-toggle="tooltip" data-placement="bottom" title="Links">La Xiir</a></li><li class="nav-item"><a class="nav-link link text-white tooltipstered display-4" href="program_schedule.html" aria-expanded="false" data-toggle="tooltip" data-placement="bottom" title="Broadcast Schedule">Jadwalka Idaacadda</a></li><li class="nav-item"><a class="nav-link link text-white tooltipstered display-4" href="contact.html" aria-expanded="false" data-toggle="tooltip" data-placement="bottom" title="Contact Us">Nagala soo xiriir</a></li></ul>
            
        </div>
    </nav>
</section>

<section class="engine"><a href="https://mobiri.se/c">web builder</a></section><section class="header1 cid-qS2Q1ZyDq2 mbr-parallax-background" id="header1-1m5">

    

    <div class="mbr-overlay" style="opacity: 0.2; background-color: rgb(0, 0, 0);">
    </div>

    <div class="container">
        <div class="row justify-content-md-center">
            <div class="mbr-white col-md-10">
                <h1 class="mbr-section-title align-center mbr-bold pb-3 mbr-fonts-style display-1">
                    Dersiga Kowaad</h1>
                <h3 class="mbr-section-subtitle align-center mbr-light pb-3 mbr-fonts-style display-2">Ilaah Keliya</h3>
                
                
            </div>
        </div>
    </div>

</section>

<section class="mbr-section article content1 cid-qwmyOtcEzW" id="content1-22">
    
     

    <div class="container">
        <div class="media-container-row">
            <div class="mbr-text col-12 col-md-8 mbr-fonts-style display-7">Waxaa jira Ilaah keliya oo weyn oo qaadir ah oo wax waliba abuuray. Waxaa jiri kara Ilaah keliya. Ilaahyada kale oo dhan waa wada been iyo bilaash.&nbsp;<div><br></div><div>Qof alla qofkii yiraahda, Ilaah ma jiro, waa nacas oo haddana kufri ah. Banii-aadmigu wuxuu u baahan yahay inuu eego oo fiiriyo adduunka uu ku kor nool yahay oo qura, si uu ku aqoonsado in Ilaah jiro. Jiritaanka adduunka qudhiisu wuxuu u caddaynayaa Abuure. Dhirta badan oo kala noocnooc ah iyo xayawaanka nool oo si kaamil ah loo wada abuuray, waxay dhammaantood caddaynayaan in Ilaaha weynu uu jiro oo iyaga abuuray. Qorraxda iyo dayaxa iyo xiddigaha oo dhammu waxay wada caddaynayaan in mid kale ay abuuratay. Midkaas kalena waa Ilaah.</div><div>"Bilowgii Ilaah samada iyo dhulkuu abuuray"</div><div>- Kitaabkii kowaad ee Muuse oo la yiraahdo Bilowgii 1:1</div><div><br></div><div>Maalintii kowaad ee uumista ayaa Ilaah wuxuu yiri, "Iftiin ha ahaado" Markiiba dhalaalkii ugu horreeyey ee iftiinka ayaa gudcurkii iftiimiyey.</div><div>"Ilaahna wuxuu arkay iftiinkii inuu wanaagsan yahay: Ilaahna iftiinkii ayuu ka soocay gudcurkii. Ilaahna iftiinkii wuxuu u bixiyey Maalin, gudcurkiina wuxuu u bixiyey Habeen"</div><div>- Bilowgii 1:4-5</div><div><br></div><div>Maalintii labaadna Ilaah wuxuu kala qaybiyey biyihii, oo wuxuu ka dhigay in samooyinka muuqdaan.&nbsp;</div><div><br></div><div>Maalintii saddexaadna</div><div>"Ilaahna wuxuu yiri, Biyaha samada ka hooseeya meel ha isugu soo urureen, oo ciidda engegani ha muuqato; sidaasayna ahaatay. Markaasuu Ilaah ciidii engegnayd u bixiyey Dhul; ururkii biyahana wuxuu u bixiyey Bado: Ilaah wuxuu arkay in taasu wanaagsan tahay."</div><div>- Bilowgii 1:9-10</div><div><br></div><div>Isla maalintaas qudheeda ayaa Ilaah wuxuu ka dhigay in dhulku soo bixiyo doog iyo dhir. Ilaah wuxuu ku farxay uumiddii uu wax uumay.&nbsp;</div><div><br></div><div>Maalintii afraadna Ilaah wuxuu abuuray qorraxda, dayaxa iyo xiddigaha. Iftiinka weynu (qorraxdu) maalinnimaduu u taliyaa, iftiinka yaruna (dayaxa) habeennimaduu u taliyaa. Xiddigaha aan tirada lahayn oo dhanna waxaa wada abuuray Ilaaha jira oo runta ah.&nbsp;</div><div><br></div><div>Maalintii shanaadna Ilaah wuxuu uumay kalluunka badda ku dhex dabaasha iyo wax kasta oo ku duula cirka iyo dhulka inta u dhexaysa. Neberiyada iyo bahallada badda iyo kalluunka waaweyn iyo kalluunka yaryar iyo gorgorada iyo shimbirrada hawada duula oo dhanba, waxaa wada uumay Ilaaha weyn.&nbsp;</div><div><br></div><div>Maalinta lixaad Ilaah wuxuu uumay xayawaanka iyo waxyaalaha dhulka ku gurguurta oo dhan. Dugaagga, xoolaha, libaaxyada, maroodiyada, iyo cayayaanka oo dhan waxaa wada uumay Ilaaha jira ee runta ah. Markii uumista ugu dambaysay ayaa Ilaah wuxuu yiri, "Aan nin inoo eg ka samayno araggeenna" - Bilowgii 1:26. Ilaah dhoobo ayuu dhulka ka qaaday oo wuxuu ka sameeyey nin. Haddana sanka labadiisa dul ayuu kaga neefsaday, markaasaa ninkii naf nool noqday.&nbsp;</div><div><br></div><div>Ilaaha runta ah oo keliya ayaa uumi kara duni saas u weyn oo qurux badan oo u wacan sida middan aan joogno oo kale. Ilaaha runta ahu sidee buu yahay?&nbsp;</div><div><br></div><div>Siyaabaha wanaagsan oo Ilaah lagu ogaan karo middood, ayaa waxay tahay in la barto dabeecooyinkiisa isaga u goonida ah. Kuwaasna waxaa ka mid ah:&nbsp;</div></div>
        </div>
    </div>
</section>

<section class="mbr-section article content11 cid-qwmKHWpMba" id="content11-27">
     

    <div class="container">
        <div class="media-container-row">
            <div class="mbr-text counter-container col-12 col-md-8 mbr-fonts-style display-7">
                <ol>
                    <li><span style="font-size: 1rem;">Ilaah wuxuu joogaa meel kasta isku mar qura. Ilaah cidina kama dhuuman karto. Goor kasta wax walba wuu u jeedaa. Ilaah waddan kastaba wuu joogaa isku mar. Nebi Daa'uud wuxuu yiri, "Xaggee baanse wejigaaga uga cararaa? ...haddaan dego badda darafyadeeda ugu shisheeyaba, Xataa halkaas gacantaada ayaa i hoggaamin doonta...Xataa gudcurku igama kaa qariyo." - Sabuurka 139:7,9,12.</span><br></li>
                    <li>Ilaah wax kasta waa yaqaan oo waa og yahay. Isagu wuu og yahay feker kasta iyo wax kasta oo ku qarsoon qalbigeenna. Nebi Daa'uud wuxuu yiri, "Rabbiyow, waad i baadhay, oo waad i soo ogaatay. Waad og tahay fadhiisashadayda iyo sarakiciddaydaba, Oo fikirkaygana meel fog baad ka garataa. Waayo Rabbiyow, eray aanad aqoonu carrabkayga kuma jiro, Laakiinse adigu waad wada og tahay." - Sabuurka 139:1-2,4. Waxaa suurowda inaan dadka wax ka qarin karno, laakiinse Ilaah innaba wax aan ka qarin karno ma jiro.</li><li>Ilaah wax kasta wuu ilaaliyaa. Ilaah caalamka isagaa uumay. Isagaana haatan xannaaneeya oo wada. Isagaa wada ilaaliya dhulka dhaqdhaqaaqiisa, oo Isagaa ilaaliya qorraxda iftiinkeeda iyo roobkaba.</li><li>Ilaah waa daa'in. Isagu bilowna ma lahayn, weligiisna dhammaad yeelan maayo. Ilaah weligiis wuu jiray, weligiisna wuu jiri doonaa. "Intaan buuruhu dhalan ka hor, Iyo intaanad samayn dhulka iyo dunida, Iyo xataa weligeed iyo weligeedba adigu waxaad tahay Ilaah." - Sabuurka 90:2</li><li>Ilaah waa xaqaani. Wax alla wixii uu sameeyaa wuu ku qumman yahay oo daacad buu ku yahay. "Rabbiyow Ilaaha Qaadirka ahow, shuqulladaadu way weyn yihiin oo, yaab bay leeyihiin. Boqorka quruumahow, jidadkaagu waa xaq oo waa run". - Muujintii Ciise Masiix oo Yooxanaa loo muujiyey 15:3.</li><li>Ilaah waa qoduus. "Qoduus, qoduus, qoduus waxaa ah Rabbiga ah Ilaaha Qaadirka ah, oo jiray oo jira oo iman doona." - Muujintii 4:8. Ilaah weligiisna qoduus buu yahay, weligiisna qoduus dhab ah buu ahaan doonaa. Taasu waa wax Ilaah lagu yaqaan oo gaar u ah. Ilaah waa qoduus, oo sidaas daraaddeed waa inuu dembiga ciqaabo. Waxyaabaha sharka ah oo aan samaynana waa dembi. Ilaah wuu neceb yahay waxyaabaha sharka ah oo aynu samayno. Isagu dembiga wuu neceb yahay, wanaaggana wuu jecel yahay.</li><li>Ilaah waa naxariis badan yahay Nebi Daa'uud wuxuu yiri, "Rabbigu jidadkiisa oo dhan wuu ku qumman yahay, Oo shuqulladiisa oo dhanna wuu ku nimco badan yahay. Rabbigu waa u dhow yahay inta isaga barida oo dhan. Kuwaas oo ah inta runta ku barida oo dhan." - Sabuurka 145:17-18.</li>
                </ol>
            </div>
        </div>
    </div>
</section>

<section class="mbr-section article content1 cid-qwmLLugWgc" id="content1-28">
    
     

    <div class="container">
        <div class="media-container-row">
            <div class="mbr-text col-12 col-md-8 mbr-fonts-style display-7">Inkastoo Ilaah neceb yahay waxyaalaha xunxun iyo dembiyada aynu samayno, haddana isagu wuxuu inoo hayaa raxmad iyo naxariis. Wuuna ina jecel yahay innaga, laakiinse dembigeenna ma uu jecla. Wuxuu innaga doonayaa inaynu ahaanno aammin iyo xaqaani. Ilaah wuxuu rag iyo dumar iyo carruurba ka doonayaa inay isaga jeclaadaan.&nbsp;<div><br></div><div>Adigu Ilaah miyaad jeceshahay? Isagu waa ku jecel yahay, laakiinse dembigaaga ma jecla.</div></div>
        </div>
    </div>
</section>

<section class="mbr-section article content10 cid-qwmArrE85F" id="content10-24">
    
     

    <div class="container">
        <div class="inner-container" style="width: 66%;">
            <hr class="line" style="width: 25%;">
            <div class="section-text align-center mbr-white mbr-fonts-style display-7">OGEYSIIS<div>&nbsp;</div><div>Waxaad yeeshaa casharka marka hore akhriso oo haddii ay suurtaggal tahay dhawr jeer ku noqnoqo,  haddaba adiga oo fahamsan oo helay dulucda casharka si degan oo fiiro gaara leh uga jawaab su’aalaha.</div><div>&nbsp;</div><div>Su’aaluhu waa toban,  shanta ugu horaysa waa doorasho, macnaha su’aal walba oo shantaasi ka mid ah waxay leedahay sadex qaybood/hab saddexdaas mid uun baa sax ah oo la oggol yahay in aad doorato. Marka ta aad dooranayso, dhibicda geeska bidix kaga taal guji.</div><div>&nbsp;</div><div>Tusaale ahaan sidan weeye:</div><div>&nbsp;</div><div><em>1. Ilaah wuxuu joogaa.</em></div><div><em>○       Meel keliya isla mar?&nbsp;</em></div><div><em>○       Laba Meelood oo keliya isku mar?</em></div><div><em>   Meel kasta isla mar?</em></div><div>&nbsp;</div><div>Ma aragtaa sidaan uga shaqeeyay su’aasha 1aad? Shanta su’aalood ee ugu horeeya sidaas ayaad uga jawaabi doontaa.</div><div>&nbsp;</div><div>Su’aasha 6 aad  ilaa iyo 8 aad ma aha sida kuwii hore, su’aasha ayaad uga soo saaraysaa jawaab ereyada casharkii aad baratay.</div><div>&nbsp;</div><div>Tusaale ahaan su’aasha 6 aad  ayaan kaaga jawaabayaa e la soco:</div><div>&nbsp;</div><div>6.<em> Ilaah waa qoduus, taas aawadeed muxuu ciqaabi doonaa?</em></div><div>“Dembi” qor meel bannaan.</div><div>Sidaas ayaad uga jawabaysaa 6 aad , 7 aad &amp; 8 aad.</div><div>&nbsp;</div><div>Su’aasha 9 aad  &amp; 10 aad waxaad kaga jawaabaysaa “R” ama “B” taas oo la macne ah&nbsp;</div><div>“Been”  ama “Run”. &nbsp;Marka aad dooranayso, dhibicda geeska bidix kaga taal guji.</div></div>
            <hr class="line" style="width: 25%;">
        </div>
    </div>
</section>

<section class="header1 cid-qS2RUX9PA3 mbr-parallax-background" id="header1-1m6">

    

    <div class="mbr-overlay" style="opacity: 0.2; background-color: rgb(0, 0, 0);">
    </div>

    <div class="container">
        <div class="row justify-content-md-center">
            <div class="mbr-white col-md-10">
                <h1 class="mbr-section-title align-center mbr-bold pb-3 mbr-fonts-style display-1">
                    Tijaabada Kowaad</h1>
                
                <p class="mbr-text align-center pb-3 mbr-fonts-style display-7">
                    Waxaad doorta jawaabta saxda ah. Saddexda jawaab mid qura ayaa sax ah. Barta oo dhinaca bidix ku taal bal guji.</p>
                
            </div>
        </div>
    </div>

</section>

    <section class="mbr-section form1 cid-qYQ3m33ogN">


        <div class="container">
            <div class="row justify-content-center">
                <div class="title col-12 col-lg-8">
                    @*<h2 class="mbr-section-title align-center pb-3 mbr-fonts-style display-2">FORM
                        </h2>*@
                    <h3 class="mbr-section-subtitle align-center mbr-light pb-3 mbr-fonts-style display-5"></h3>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row justify-content-center">
                <div class="media-container-column col-lg-8">
                    <div data-form-alert="" hidden="">
                        <p>@submitMessage</p>
                    </div>

                    <form method="post">

                        <div class="form-check">
                            @Q1<br />
                            <div>
                                <input class="form-check-input" id="A1" name="A1" type="radio" value="Meel keliya isla mar" />
                                <label class="form-check-label" for="A1">Meel keliya isla mar.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A1" name="A1" type="radio" value="Laba meelood oo keliya isku mar" />
                                <label class="form-check-label" for="A1">Laba meelood oo keliya isku mar.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A1" name="A1" type="radio" value="Meel kasta isla mar" />
                                <label class="form-check-label" for="A1">Meel kasta isla mar.</label>
                            </div>
                        </div>
                        <div class="form-check">
                            @Q2<br />    
                            <div>
                                <input class="form-check-input" id="A2" name="A2" type="radio" value="Qorraxda, dayaxa iyo xiddigaha." />
                                <label class="form-check-label" for="A2">Qorraxda, dayaxa iyo xiddigaha.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A2" name="A2" type="radio" value="Kalluunka, shimbirraha iyo haadda." />
                                <label class="form-check-label" for="A2">Kalluunka, shimbirraha iyo haadda.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A2" name="A2" type="radio" value="Nin." />
                                <label class="form-check-label" for="A2">Nin.</label>
                            </div>
                        </div>

                        <div class="form-check">
                            @Q3<br />
                            <div>
                                <input class="form-check-input" id="A3" name="A3" type="radio" value="In isaga ragga keliyuhu jeclaado." />
                                <label class="form-check-label" for="A3">In isaga ragga keliyuhu jeclaado.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A3" name="A3" type="radio" value="In isaga dumarka keliyuhu jeclaado." />
                                <label class="form-check-label" for="A3">In isaga dumarka keliyuhu jeclaado.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A3" name="A3" type="radio" value="In isaga ragga iyo dumarka, iyo carruurtuba ay wada jeclaadaan." />
                                <label class="form-check-label" for="A3">In isaga ragga iyo dumarka, iyo carruurtuba ay wada jeclaadaan.</label>
                            </div>
                            <br />
                        </div>

                        <div class="form-check">
                            @Q4<br />
                            <div>
                                <input class="form-check-input" id="A4" name="A4" type="radio" value="Wuxuu kala soocay birriga iyo badaha.">
                                <label class="form-check-label" for="A4">Wuxuu kala soocay birriga iyo badaha.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A4" name="A4" type="radio" value="Wuxuu uumay nin." />
                                <label class="form-check-label" for="A4">Wuxuu uumay nin.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A4" name="A4" type="radio" value="Wuxuu yiri, &quot;Iftiin ha ahaado&quot;" />
                                <label class="form-check-label" for="A4">Wuxuu yiri, &quot;Iftiin ha ahaado&quot;</label>
                            </div>
                        </div>

                        <div class="form-check">
                            @Q5<br />
                            <div>
                                <input class="form-check-input" id="A5" name="A5" type="radio" value="Dembigeenna." />
                                <label class="form-check-label" for="A5">Dembigeenna.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A5" name="A5" type="radio" value="Innaga iyo dembigeennaba." />
                                <label class="form-check-label" for="A5">Innaga iyo dembigeennaba.</label>
                            </div>
                            <div>
                                <input class="form-check-input" id="A5" name="A5" type="radio" value="Innaga." />
                                <label class="form-check-label" for="A5">Innaga.</label>
                            </div>
                        </div>

                        <div class="form-group">
                            @Q6<br />
                            <input type="text" name="A6" class="form-control" />
                        </div>

                        <div class="form-group">
                            @Q7<br />
                            <input type="text" name="A7" class="form-control" />
                        </div>

                        <div class="form-group">
                            @Q8<br />
                            <input type="text" name="A8" class="form-control" />
                        </div>

                        <div class="form-group">
                            @Q9<br />
                                <input class="form-check-input" id="A9" name="A9" type="radio" value="Run" /> Run<br />
                                <input class="form-check-input" id="A9" name="A9" type="radio" value="Been" /> Been<br />
                        </div>
                        <div class="form-group">
                            @Q10<br />
                                <input class="form-check-input" id="A10" name="A10" type="radio" value="Run" /> Run<br />
                                <input class="form-check-input" id="A10" name="A10" type="radio" value="Been" /> Been<br />
                        </div>

                        <br />
                            <div class="form-group">
                                <label for="tbName" class="form-control-label mbr-fonts-style display-7">Magacaaga oo dhan: </label><br />
                                <input type="text" value="@Request.Form("tbName")" name="tbName" class="form-control" @Validation.For("tbName") />
                            </div>
                            <div class="form-group">
                                <label for="tbEmail" class="form-control-label mbr-fonts-style display-7">Cinwaanka Iimaylka:</label><br />
                                <input type="email" name="tbEmail" class="form-control" @Validation.For("tbEmail") />
                            </div>
                            <div class="row row-sm-offset">

                                <div class="col-md-4 multi-horizontal">
                                    <div class="form-group">
                                        <label for="tbCity" class="form-control-label mbr-fonts-style display-7">Magaalada:</label><br />
                                        <input type="text" name="tbCity" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-4 multi-horizontal">
                                    <div class="form-group">
                                        <label for="tbCountry" class="form-control-label mbr-fonts-style display-7">Waddanka:</label><br />
                                        <input type="text" name="tbCountry" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbComment" class="form-control-label mbr-fonts-style display-7">Su'aal ama Ra'yi:</label><br />
                                <textarea type="text" rows="3" name="tbComment" class="form-control"></textarea>
                            </div>
                            <span class="input-group-btn">
                                <input type="submit" style="z-index: 1;" value=" Riix oo dir " class="btn btn-primary btn-form display-4" />
                            </span>
</form>
                </div>
            </div>
        </div>
    </section>

<section class="mbr-section content8 cid-qYbwJGqWj6" id="content8-4in">

    

    <div class="container">
        <div class="media-container-row title">
            <div class="col-12 col-md-8">
                <div class="mbr-section-btn align-center"><a class="btn btn-primary tooltipstered display-4" href="ikjk_2.html" data-toggle="tooltip" data-placement="bottom" title="Chapter 2">Dersiga Labaad</a> 
                    <a class="btn btn-primary tooltipstered display-4" href="ikjk_default.html" data-toggle="tooltip" data-placement="bottom" title="One Way One God Home">Ilaah Keliya Iyo Jid Keliya&nbsp;</a></div>
            </div>
        </div>
    </div>
</section>

<section once="" class="cid-qwmWhm6gE9" id="footer6-2g">

    

    

    <div class="container">
        <div class="media-container-row align-center mbr-white">
            <div class="col-12">
                <p class="mbr-text mb-0 mbr-fonts-style display-7">
                    © Copyright 2018 Nolosha Cusub - All Rights Reserved
                </p>
            </div>
        </div>
    </div>
</section>


  <script src="assets/web/assets/jquery/jquery.min.js"></script>
  <script src="assets/popper/popper.min.js"></script>
  <script src="assets/tether/tether.min.js"></script>
  <script src="assets/bootstrap/js/bootstrap.min.js"></script>
  <script src="assets/dropdown/js/script.min.js"></script>
  <script src="assets/smoothscroll/smooth-scroll.js"></script>
  <script src="assets/touchswipe/jquery.touch-swipe.min.js"></script>
  <script src="assets/viewportchecker/jquery.viewportchecker.js"></script>
  <script src="assets/parallax/jarallax.min.js"></script>
  <script src="assets/theme/js/script.js"></script>
  <script src="assets/formoid/formoid.min.js"></script>
  
  <!--For hover over pop up translations, per example of Bootstrap 4 Tooltip https://www.w3schools.com/bootstrap4/bootstrap_tooltip.asp-->

<script>
$(document).ready(function(){
    $('[data-toggle="tooltip"]').tooltip();   
});
</script>
  <input name="animation" type="hidden">
   <div id="scrollToTop" class="scrollToTop mbr-arrow-up"><a style="text-align: center;"><i></i></a></div>
  </body>
</html>