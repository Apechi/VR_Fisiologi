using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;
    

    public Question(string question, string[] answers, int correctAnswerIndex)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswerIndex = correctAnswerIndex;
    }

}

public class QuizManager : MonoBehaviour
{
   
    public TMP_Text questionText;
    public Button[] answerButtons;

    

    public Question[] questions;
    private int currentQuestionIndex;
    private int score;

     [SerializeField] private GameObject panel_finished;
     [SerializeField] private GameObject panel_start;
     [SerializeField] private TMP_Text scoreText;

     [Range(0, 11)]
    public int pilih_Bab = 0;


    private void Start()
    {
        if (pilih_Bab != 0) {

          soalMateriTemplate(pilih_Bab);

        }
        ShuffleQuestions();
        ShowQuestion(0);
        panel_finished.SetActive(false);
        panel_start.SetActive(true);
    }

    private void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Length; i++)
        {
            Question temp = questions[i];
            int randomIndex = Random.Range(i, questions.Length);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
    }

    public void ShowQuestion(int questionIndex)
    {
        questionText.text = questions[questionIndex].question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = questions[questionIndex].answers[i];
        }

        currentQuestionIndex = questionIndex;
    }

    public void OnAnswerButtonClicked(int answerIndex)
    {
        if (answerIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            score += 10;
            Debug.Log("Correct!");
         
        }
        else
        {
            Debug.Log("Incorrect!");
           
        }

        int nextQuestionIndex = currentQuestionIndex + 1;
        if (nextQuestionIndex < questions.Length)
        {
            ShowQuestion(nextQuestionIndex);
        }
        else
        {
            panel_finished.SetActive(true);
            panel_start.SetActive(false);
            scoreText.text = $"Score Kamu: {score.ToString()}";
            Debug.Log("Quiz completed!");
            Debug.Log("Score: " + score);
        }
    }

    public void soalMateriTemplate(int bab) {
        switch (bab)
        {   
            case 1: 
            questions = new Question[]
            {
                new Question("Apa fungsi utama mitokondria?", new string[] { "Pembuatan protein", "Pengendalian sel", "Produksi energi", "Pencernaan makanan" }, 2),
                new Question("Di mana proses respirasi seluler terutama terjadi?", new string[] { "Sitoplasma", "Ribosom", "Nukleus", "Mitokondria" }, 3),
                new Question("Apa nama protein yang mengangkut oksigen dalam darah?", new string[] { "Hemoglobin", "Insulin", "Glukosa", "Keratin" }, 0),
                new Question("Apa yang dimaksud dengan homeostasis?", new string[] { "Keseimbangan dalam sel", "Pertumbuhan sel", "Pemecahan sel", "Penggantian sel" }, 0),
                new Question("Apa nama cairan yang melindungi dan memberi nutrisi pada sel?", new string[] { "Air", "Mineral", "Sitosol", "Limfa" }, 2),
                new Question("Apa fungsi utama sistem saraf?", new string[] { "Pencernaan makanan", "Koordinasi tubuh", "Penglihatan", "Detoksifikasi" }, 1),
                new Question("Apa yang dihasilkan selama fotosintesis?", new string[] { "Oksigen", "Karbon dioksida", "Glukosa", "Asam amino" }, 2),
                new Question("Apa yang dilakukan oleh enzim dalam sel?", new string[] { "Menyusutkan sel", "Memproduksi energi", "Mempercepat reaksi kimia", "Menghentikan pernapasan" }, 2),
                new Question("Di mana sebagian besar penyerapan nutrisi dari makanan terjadi?", new string[] { "Lambung", "Usus kecil", "Jantung", "Paru-paru" }, 1),
                new Question("Apa yang dimaksud dengan osmosis?", new string[] { "Gerakan partikel melalui membran sel", "Pertumbuhan sel", "Penggandakan sel", "Pencernaan sel" }, 0)
            };
            break;

            case 2:
            questions = new Question[]
            {
                new Question("Apa organ yang bertanggung jawab untuk pencernaan awal makanan?", new string[] { "Usus", "Jantung", "Mulut", "Paru-paru" }, 2),
                new Question("Apa enzim yang ditemukan di dalam lambung yang membantu pencernaan protein?", new string[] { "Amilase", "Pepsin", "Lipase", "Trypsin" }, 1),
                new Question("Di mana penyerapan nutrisi utama dalam pencernaan terjadi?", new string[] { "Usus besar", "Usus kecil", "Lambung", "Kolon" }, 1),
                new Question("Apa fungsi utama usus besar dalam sistem pencernaan?", new string[] { "Pencernaan karbohidrat", "Penyimpanan makanan", "Penyerapan air", "Pencernaan lemak" }, 2),
                new Question("Apa yang disebut dengan tindakan mekanis pertama dalam pencernaan makanan?", new string[] { "Fermentasi", "Peristaltik", "Pengunyahan", "Ekskresi" }, 2),
                new Question("Apa nama organ yang menghasilkan empedu?", new string[] { "Hati", "Pankreas", "Lambung", "Ginjal" }, 0),
                new Question("Apa nama enzim yang diproduksi oleh pankreas dan membantu pencernaan karbohidrat?", new string[] { "Pepsin", "Amylase", "Trypsin", "Lipase" }, 1),
                new Question("Apa yang terjadi selama proses emulsi dalam pencernaan lemak?", new string[] { "Pemecahan lemak menjadi asam lemak", "Pemecahan protein menjadi asam amino", "Pemecahan karbohidrat menjadi glukosa", "Pemecahan air menjadi oksigen dan hidrogen" }, 0),
                new Question("Apa nama bagian dari sistem pencernaan yang menghubungkan tenggorokan dengan lambung?", new string[] { "Usus besar", "Usus kecil", "Esophagus", "Pankreas" }, 2),
                new Question("Apa yang disebut dengan proses mengunyah makanan?", new string[] { "Pengasaman", "Peristaltik", "Pengunyahan", "Pengeluaran" }, 2)
            };
            break;

             case 3:
             questions = new Question[]
            {
                new Question("Apa organ utama dalam sistem pernapasan manusia?", new string[] { "Hati", "Paru-paru", "Usus", "Jantung" }, 1),
                new Question("Apa yang disebut dengan pertukaran gas antara darah dan jaringan tubuh?", new string[] { "Ekspirasi", "Inspirasi", "Sirkulasi", "Respirasi" }, 3),
                new Question("Apa yang menyebabkan inspirasi (masuknya udara ke paru-paru)?", new string[] { "Kontraksi otot interkostal", "Relaksasi diafragma", "Kontraksi otot perut", "Relaksasi otot punggung" }, 0),
                new Question("Apa yang terjadi saat ekspirasi (keluarnya udara dari paru-paru)?", new string[] { "Paru-paru memuai", "Paru-paru menyusut", "Jantung berdetak kencang", "Peningkatan suhu tubuh" }, 1),
                new Question("Apa yang mengangkut oksigen dari paru-paru ke seluruh tubuh?", new string[] { "Hemoglobin", "Insulin", "Glukosa", "Keratin" }, 0),
                new Question("Apa yang disebut dengan perubahan dalam kapasitas paru-paru?", new string[] { "Ketosis", "Tidal volume", "Vital capacity", "Peristaltik" }, 2),
                new Question("Apa nama penyakit pernapasan yang ditandai dengan peradangan paru-paru dan kesulitan bernafas?", new string[] { "Asma", "Diabetes", "Hipertensi", "Pneumonia" }, 3),
                new Question("Apa yang menyebabkan asma?", new string[] { "Infeksi bakteri", "Alergi dan peradangan", "Kurangnya oksigen", "Overdosis obat" }, 1),
                new Question("Apa yang dilakukan oleh diafragma selama pernapasan?", new string[] { "Relaksasi", "Kontraksi", "Berhenti bergerak", "Membengkok" }, 1),
                new Question("Apa yang terjadi saat sel-sel tubuh menghasilkan karbon dioksida?", new string[] { "Ekspirasi", "Inspirasi", "Sirkulasi", "Respirasi" }, 0)
            };
            break;

             case 4:
             questions = new Question[]
            {
                new Question("Apa organ utama dalam sistem peredaran darah manusia?", new string[] { "Paru-paru", "Jantung", "Usus", "Hati" }, 1),
                new Question("Apa yang disebut dengan pembekuan darah untuk menghentikan perdarahan?", new string[] { "Koagulasi", "Infiltrasi", "Respirasi", "Agregasi" }, 0),
                new Question("Apa yang membawa oksigen dari paru-paru ke jaringan tubuh?", new string[] { "Plasma", "Eritrosit", "Leukosit", "Trombosit" }, 1),
                new Question("Apa yang memompa darah ke seluruh tubuh?", new string[] { "Paru-paru", "Aorta", "Jantung", "Hati" }, 2),
                new Question("Apa nama katup yang terletak antara atrium dan ventrikel kiri?", new string[] { "Katup mitral", "Katup aorta", "Katup trikuspid", "Katup pulmonal" }, 0),
                new Question("Apa yang mengatur detak jantung?", new string[] { "Otak", "Pankreas", "Sistem saraf otonom", "Usus" }, 2),
                new Question("Apa yang disebut dengan tekanan darah yang lebih rendah saat jantung beristirahat?", new string[] { "Tekanan sistolik", "Tekanan diastolik", "Tekanan arteri", "Tekanan vena" }, 1),
                new Question("Apa yang membawa darah dari jantung ke paru-paru untuk oksigenasi?", new string[] { "Aorta", "Vena kava superior", "Vena pulmonal", "Vena cava inferior" }, 2),
                new Question("Apa yang disebabkan oleh penyumbatan pembuluh darah koroner yang memasok jantung?", new string[] { "Diabetes", "Hipertensi", "Aterosklerosis", "Asma" }, 2),
                new Question("Apa yang disebut dengan jumlah darah yang dipompa oleh jantung dalam satu kontraksi?", new string[] { "Denervasi", "Stroke volume", "Vena", "Elektrolit" }, 1)
            };
            break;

             case 5:
             questions = new Question[]
            {
                new Question("Apa organ utama yang bertanggung jawab untuk menghasilkan urin?", new string[] { "Hati", "Paru-paru", "Usus", "Ginjal" }, 3),
                new Question("Apa yang disebut sebagai proses penghilangan zat-zat sisa dari darah melalui ginjal?", new string[] { "Ekskresi", "Respirasi", "Koagulasi", "Agregasi" }, 0),
                new Question("Apa yang merupakan produk akhir metabolisme protein dan diekskresikan dalam urin?", new string[] { "Karbon dioksida", "Urea", "Glikogen", "Insulin" }, 1),
                new Question("Apa yang mengatur keseimbangan air dalam tubuh?", new string[] { "Sistem pencernaan", "Hati", "Ginjal", "Pankreas" }, 2),
                new Question("Apa yang disebut dengan penumpukan cairan berlebih dalam jaringan tubuh?", new string[] { "Dehidrasi", "Edema", "Ketosis", "Hipotensi" }, 1),
                new Question("Apa yang mengendalikan rasa haus dan produksi urin?", new string[] { "Hipotalamus", "Korteks", "Medula", "Hormon insulin" }, 0),
                new Question("Apa yang terjadi ketika ginjal gagal mengeluarkan limbah dan racun dari tubuh?", new string[] { "Ketosis", "Edema", "Gagal ginjal", "Diabetes" }, 2),
                new Question("Apa nama hormon yang mengatur tekanan darah dan keseimbangan elektrolit dalam tubuh?", new string[] { "Insulin", "Adrenalin", "Aldosteron", "Glukagon" }, 2),
                new Question("Apa yang merupakan cairan utama dalam tubuh yang berfungsi sebagai pelarut dan pengangkut zat-zat?", new string[] { "Urea", "Plasma", "Lipid", "Glukosa" }, 1),
                new Question("Apa yang disebut dengan kondisi ketika kadar gula darah terlalu tinggi?", new string[] { "Hipertensi", "Hipoglikemia", "Hiperglikemia", "Ketosis" }, 2)
            };
            break;

             case 6:
                questions = new Question[]
            {
                new Question("Apa yang merupakan sel-sel saraf yang mengirimkan sinyal dari tubuh ke otak atau sumsum tulang belakang?", new string[] { "Neuron motorik", "Neuron sensorik", "Neuron interkoneksi", "Neuron eferen" }, 1),
                new Question("Apa yang disebut dengan sel-sel saraf yang mengirimkan sinyal dari otak atau sumsum tulang belakang ke otot atau kelenjar?", new string[] { "Neuron motorik", "Neuron sensorik", "Neuron interkoneksi", "Neuron aferen" }, 0),
                new Question("Apa yang merupakan substansi kimia yang digunakan oleh sel-sel saraf untuk mengirim sinyal ke sel-sel lain?", new string[] { "Insulin", "Glukagon", "Neurotransmitter", "Hormon" }, 2),
                new Question("Apa yang merupakan pusat pengaturan utama bagi berbagai fungsi tubuh seperti pernapasan dan detak jantung?", new string[] { "Korteks serebri", "Medula spinalis", "Hipotalamus", "Sistem limbik" }, 1),
                new Question("Apa yang disebut dengan selaput tipis yang mengelilingi dan melindungi sel saraf?", new string[] { "Mielin", "Akson", "Dendrit", "Aksoplasma" }, 0),
                new Question("Apa yang merupakan cabang utama sistem saraf otonom yang mengatur respons fight or flight?", new string[] { "Sistem parasimpatik", "Sistem somatik", "Sistem simpatik", "Sistem sentral" }, 2),
                new Question("Apa yang disebut dengan pusat pengaturan yang mengendalikan keseimbangan dan koordinasi gerakan tubuh?", new string[] { "Medula spinalis", "Korteks serebri", "Cerebellum", "Sistem limbik" }, 2),
                new Question("Apa yang menghubungkan dua belahan otak dan memungkinkan komunikasi antara mereka?", new string[] { "Korpus kalosum", "Akson", "Dendrit", "Medulla oblongata" }, 0),
                new Question("Apa yang disebut dengan sel-sel kecil yang menyebabkan reaksi refleks dalam sistem saraf?", new string[] { "Neuron motorik", "Neuron sensorik", "Neuron interkoneksi", "Neuron aferen" }, 2),
                new Question("Apa yang disebut dengan sistem saraf yang mengatur fungsi-fungsi tubuh yang tidak tergantung pada kehendak?", new string[] { "Sistem saraf pusat", "Sistem saraf somatik", "Sistem saraf otonom", "Sistem saraf perifer" }, 2)
            };

            break;

             case 7:
            questions = new Question[]
            {
                new Question("Apa jenis otot yang bekerja tanpa kesadaran dan mengendalikan fungsi-fungsi tubuh seperti peredaran darah dan pencernaan?", new string[] { "Otot rangka", "Otot polos", "Otot jantung", "Otot striated" }, 1),
                new Question("Apa nama protein utama yang memungkinkan kontraksi otot?", new string[] { "Keratin", "Kollagen", "Myosin", "Hemoglobin" }, 2),
                new Question("Apa yang disebut sebagai ketegangan konstan dalam otot saat istirahat?", new string[] { "Atonia", "Isometrik", "Isotonik", "Tonisitas" }, 3),
                new Question("Apa yang memicu kontraksi otot dalam respons terhadap rangsangan saraf?", new string[] { "Serotonin", "Adrenalin", "Kalsium", "Glukosa" }, 2),
                new Question("Apa yang disebut dengan otot yang berkontraksi saat panjangnya berkurang?", new string[] { "Isotonik", "Isometrik", "Isokinetik", "Isotonus" }, 0),
                new Question("Apa yang disebut dengan kelompok serat otot yang dikendalikan oleh satu saraf motorik?", new string[] { "Sel motorik", "Unit motorik", "Sel otot", "Sel neurologis" }, 1),
                new Question("Apa yang memungkinkan otot untuk menghasilkan energi melalui metabolisme anaerobik saat oksigen terbatas?", new string[] { "Glikogen", "Glukosa", "Kreatin fosfat", "Karbon dioksida" }, 0),
                new Question("Apa yang disebut dengan pembesaran otot sebagai respons terhadap latihan beban berulang?", new string[] { "Hipertrofi", "Atrofi", "Distrofi", "Ataksia" }, 0),
                new Question("Apa yang memungkinkan otot untuk merespon dengan cepat terhadap impuls saraf?", new string[] { "Sarkoplasma", "Mielin", "Sarcolemma", "Sarkomer" }, 2),
                new Question("Apa yang disebut dengan proses pemulihan otot setelah latihan atau cedera?", new string[] { "Rehabilitasi", "Remodeling", "Rekonstruksi", "Rekuperasi" }, 3)
            };
            break;

             case 8:
             questions = new Question[]
            {
                new Question("Apa yang merupakan bentuk energi termal yang mengukur suhu?", new string[] { "Kalori", "Kelvin", "Kilowatt", "Kilogram" }, 1),
                new Question("Apa yang disebut dengan perpindahan panas melalui kontak langsung antara benda-benda yang memiliki perbedaan suhu?", new string[] { "Radiasi", "Konduksi", "Konveksi", "Evolusi" }, 1),
                new Question("Apa yang merupakan isolator termal yang baik?", new string[] { "Logam", "Kayu", "Kaca", "Plastik" }, 1),
                new Question("Apa yang disebut dengan perpindahan panas melalui gerakan massa fluida yang memindahkan energi termal?", new string[] { "Radiasi", "Konduksi", "Konveksi", "Evolusi" }, 2),
                new Question("Apa yang disebut dengan proses radiasi panas yang memancar dari suatu benda ke benda lain tanpa perantara?", new string[] { "Evaporasi", "Konduksi", "Radiasi", "Konveksi" }, 2),
                new Question("Apa yang merupakan unit ukuran suhu dalam sistem metrik?", new string[] { "Fahrenheit", "Celsius", "Kelvin", "Rankine" }, 1),
                new Question("Apa yang disebut dengan perubahan wujud dari cairan menjadi gas?", new string[] { "Sublimasi", "Kondensasi", "Evolusi", "Penguapan" }, 3),
                new Question("Apa yang merupakan panas yang diperlukan untuk mengubah suatu zat dari wujud padat menjadi cairan pada suhu tertentu?", new string[] { "Panjang gelombang", "Kapasitas kalor", "Kalor laten", "Konstanta Boltzmann" }, 2),
                new Question("Apa yang disebut dengan hukum termodinamika yang menyatakan bahwa panas akan aliran dari benda dengan suhu tinggi ke benda dengan suhu rendah?", new string[] { "Hukum termodinamika pertama", "Hukum termodinamika kedua", "Hukum Fourier", "Hukum Stefan-Boltzmann" }, 1),
                new Question("Apa yang merupakan suhu terendah yang dapat dicapai dalam skala Kelvin?", new string[] { "0 K", "0 °C", "0 °F", "0 R" }, 0)
            };

            break;
             case 9:
             questions = new Question[]
            {
                new Question("Apa yang merupakan sel kelamin jantan?", new string[] { "Ovum", "Sperma", "Zigot", "Endometrium" }, 1),
                new Question("Apa yang disebut dengan proses pembelahan sel yang menghasilkan sel-sel kelamin?", new string[] { "Oogenesis", "Spermatogenesis", "Fertilisasi", "Implantasi" }, 0),
                new Question("Apa yang merupakan organ yang menghasilkan sel telur pada wanita?", new string[] { "Ovarium", "Testis", "Uterus", "Vagina" }, 0),
                new Question("Apa yang memicu menstruasi pada wanita?", new string[] { "Hormon testosteron", "Hormon estrogen", "Hormon prolaktin", "Hormon insulin" }, 1),
                new Question("Apa yang disebut dengan penyatuan sel telur dan sperma untuk membentuk zigot?", new string[] { "Fertilisasi", "Ovulasi", "Menstruasi", "Implantasi" }, 0),
                new Question("Apa yang merupakan lapisan rahim yang diperlukan untuk implantasi embrio?", new string[] { "Myometrium", "Endometrium", "Perimetrium", "Ovarium" }, 1),
                new Question("Apa yang menghasilkan hormon progesteron selama kehamilan?", new string[] { "Ovarium", "Testis", "Plasenta", "Uterus" }, 2),
                new Question("Apa yang disebut dengan proses pematangan sel telur dalam ovarium?", new string[] { "Fertilisasi", "Ovulasi", "Menstruasi", "Implantasi" }, 1),
                new Question("Apa yang memungkinkan janin untuk menerima oksigen dan nutrisi dari ibu selama kehamilan?", new string[] { "Ari-ari", "Plasenta", "Amnion", "Umbilikal" }, 1),
                new Question("Apa yang merupakan saluran yang menghubungkan ovarium dengan rahim?", new string[] { "Oviduk", "Ureter", "Bronkus", "Jejunum" }, 0)
            };

            break;

             case 10:
             questions = new Question[]
            {
                new Question("Apa yang merupakan proses regulasi internal tubuh untuk menjaga kondisi yang stabil?", new string[] { "Metabolisme", "Homeostasis", "Hipertrofi", "Katabolisme" }, 1),
                new Question("Apa yang disebut dengan organ yang mengatur keseimbangan air dalam tubuh?", new string[] { "Paru-paru", "Jantung", "Ginjal", "Hati" }, 2),
                new Question("Apa yang merupakan hormon yang mengatur kadar glukosa darah?", new string[] { "Insulin", "Adrenalin", "Testosteron", "Kortisol" }, 0),
                new Question("Apa yang disebut dengan kondisi di mana tekanan darah terlalu rendah?", new string[] { "Hipertensi", "Hipotensi", "Aterosklerosis", "Hiperglikemia" }, 1),
                new Question("Apa yang mengatur suhu tubuh saat kondisi panas dengan mengeluarkan keringat?", new string[] { "Hipotalamus", "Korteks serebri", "Medula spinalis", "Kelenjar adrenal" }, 0),
                new Question("Apa yang merupakan organ yang menghasilkan hormon insulin dan glukagon?", new string[] { "Ginjal", "Hati", "Pankreas", "Usus" }, 2),
                new Question("Apa yang disebut dengan peningkatan jumlah sel darah merah dalam respons terhadap hipoksia?", new string[] { "Eritropoiesis", "Leukopoiesis", "Trombopoiesis", "Melanogenesis" }, 0),
                new Question("Apa yang memungkinkan sel untuk menyerap glukosa dari darah dan menurunkan kadar glukosa darah?", new string[] { "Insulin", "Adrenalin", "Testosteron", "Kortisol" }, 0),
                new Question("Apa yang merupakan hormon yang memicu perubahan dalam sirkulasi dan tekanan darah?", new string[] { "Progesteron", "Estrogen", "Adrenalin", "Testosteron" }, 2),
                new Question("Apa yang disebut dengan penurunan suhu tubuh saat kondisi dingin dengan berkedutnya otot?", new string[] { "Hipotalamus", "Korteks serebri", "Medula spinalis", "Kelenjar adrenal" }, 0)
            };
            break;

             case 11:
             questions = new Question[]
            {
                new Question("Apa yang merupakan indra yang digunakan untuk mendengar suara?", new string[] { "Mata", "Telinga", "Hidung", "Lidah" }, 1),
                new Question("Apa yang disebut sebagai indra yang digunakan untuk melihat warna dan bentuk objek?", new string[] { "Telinga", "Hidung", "Lidah", "Mata" }, 3),
                new Question("Apa yang merupakan indra yang digunakan untuk merasakan bau dan aroma?", new string[] { "Lidah", "Hidung", "Kulit", "Telinga" }, 1),
                new Question("Apa yang digunakan untuk mendeteksi rasa makanan, termasuk manis, asam, asin, dan pahit?", new string[] { "Lidah", "Hidung", "Kulit", "Telinga" }, 0),
                new Question("Apa yang merupakan indra yang digunakan untuk merasakan sentuhan dan tekanan?", new string[] { "Lidah", "Hidung", "Kulit", "Telinga" }, 2),
                new Question("Apa yang disebut dengan indra yang digunakan untuk merasakan perasaan dingin, panas, dan nyeri?", new string[] { "Hidung", "Lidah", "Kulit", "Telinga" }, 2),
                new Question("Apa yang digunakan untuk mendeteksi perubahan posisi tubuh?", new string[] { "Lidah", "Hidung", "Kulit", "Telinga" }, 3),
                new Question("Apa yang merupakan indra yang digunakan untuk mendeteksi tekanan udara dan getaran suara?", new string[] { "Kulit", "Hidung", "Telinga", "Lidah" }, 2),
                new Question("Apa yang digunakan untuk mendeteksi rasa makanan, termasuk manis, asam, asin, dan pahit?", new string[] { "Lidah", "Hidung", "Kulit", "Telinga" }, 0),
                new Question("Apa yang disebut sebagai indra yang digunakan untuk merasakan perubahan posisi tubuh?", new string[] { "Lidah", "Hidung", "Kulit", "Telinga" }, 3)
            };

            break;


            default:
            questions = new Question[]
            {
                new Question("Apa fungsi utama mitokondria?", new string[] { "Pembuatan protein", "Pengendalian sel", "Produksi energi", "Pencernaan makanan" }, 2),
                new Question("Di mana proses respirasi seluler terutama terjadi?", new string[] { "Sitoplasma", "Ribosom", "Nukleus", "Mitokondria" }, 3),
                new Question("Apa nama protein yang mengangkut oksigen dalam darah?", new string[] { "Hemoglobin", "Insulin", "Glukosa", "Keratin" }, 0),
                new Question("Apa yang dimaksud dengan homeostasis?", new string[] { "Keseimbangan dalam sel", "Pertumbuhan sel", "Pemecahan sel", "Penggantian sel" }, 0),
                new Question("Apa nama cairan yang melindungi dan memberi nutrisi pada sel?", new string[] { "Air", "Mineral", "Sitosol", "Limfa" }, 2),
                new Question("Apa fungsi utama sistem saraf?", new string[] { "Pencernaan makanan", "Koordinasi tubuh", "Penglihatan", "Detoksifikasi" }, 1),
                new Question("Apa yang dihasilkan selama fotosintesis?", new string[] { "Oksigen", "Karbon dioksida", "Glukosa", "Asam amino" }, 2),
                new Question("Apa yang dilakukan oleh enzim dalam sel?", new string[] { "Menyusutkan sel", "Memproduksi energi", "Mempercepat reaksi kimia", "Menghentikan pernapasan" }, 2),
                new Question("Di mana sebagian besar penyerapan nutrisi dari makanan terjadi?", new string[] { "Lambung", "Usus kecil", "Jantung", "Paru-paru" }, 1),
                new Question("Apa yang dimaksud dengan osmosis?", new string[] { "Gerakan partikel melalui membran sel", "Pertumbuhan sel", "Penggandakan sel", "Pencernaan sel" }, 0)
            };
            break;
        }
    }

}
