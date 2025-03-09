using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<Soal> daftarSoal;
    public Image gambarSoal;
    public TMP_Text teksSoal;
    public Image[] tombolJawaban;
    public TMP_Text teksSkor;
    public TMP_Text teksIndikator;

    // Tombol tambahan
    public Image tombolRestart;

    // Audio
    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;
    public AudioClip sfxBenar;
    public AudioClip sfxSalah;

    private List<Soal> soalTersisa;
    private int skor = 0;
    private int indexSoal = 0;

    void Start()
    {
        soalTersisa = new List<Soal>(daftarSoal);
        ShuffleSoal();

        teksSkor.gameObject.SetActive(false);
        teksIndikator.gameObject.SetActive(false);
        tombolRestart.gameObject.SetActive(false);

        if (bgmAudioSource != null)
        {
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }

        TampilkanSoalBerikutnya();
    }

    void ShuffleSoal()
    {
        for (int i = 0; i < soalTersisa.Count; i++)
        {
            Soal temp = soalTersisa[i];
            int randomIndex = Random.Range(i, soalTersisa.Count);
            soalTersisa[i] = soalTersisa[randomIndex];
            soalTersisa[randomIndex] = temp;
        }
    }

    void TampilkanSoalBerikutnya()
    {
        if (indexSoal >= soalTersisa.Count)
        {
            SelesaiKuis();
            return;
        }

        Soal soalSaatIni = soalTersisa[indexSoal];

        teksSoal.text = soalSaatIni.pertanyaan;
        gambarSoal.sprite = soalSaatIni.gambar;

        for (int i = 0; i < tombolJawaban.Length; i++)
        {
            if (i < soalSaatIni.pilihanJawaban.Length)
            {
                tombolJawaban[i].gameObject.SetActive(true);
                tombolJawaban[i].GetComponentInChildren<TMP_Text>().text = soalSaatIni.pilihanJawaban[i];

                int pilihanIndexCopy = i;
                Button btn = tombolJawaban[i].GetComponent<Button>();
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => StartCoroutine(PeriksaJawaban(pilihanIndexCopy)));
            }
            else
            {
                tombolJawaban[i].gameObject.SetActive(false);
            }
        }
    }

    IEnumerator PeriksaJawaban(int index)
    {
        Soal soalSaatIni = soalTersisa[indexSoal];

        if (index == soalSaatIni.jawabanBenarIndex)
        {
            skor += 10;
            if (sfxAudioSource != null && sfxBenar != null)
            {
                sfxAudioSource.PlayOneShot(sfxBenar);
            }
        }
        else
        {
            if (sfxAudioSource != null && sfxSalah != null)
            {
                sfxAudioSource.PlayOneShot(sfxSalah);
            }
        }

        yield return new WaitForSeconds(2f);

        indexSoal++;
        TampilkanSoalBerikutnya();
    }

    void SelesaiKuis()
    {
        gambarSoal.gameObject.SetActive(false);
        teksSoal.gameObject.SetActive(false);

        foreach (Image tombol in tombolJawaban)
        {
            tombol.gameObject.SetActive(false);
        }

        teksSkor.gameObject.SetActive(true);
        teksSkor.text = "Skor Akhir: " + skor;

        teksIndikator.gameObject.SetActive(true);
        if (skor < 20)
        {
            teksIndikator.text = "Belajar lagi yaa...";
            teksIndikator.color = Color.red;
        }
        else
        {
            teksIndikator.text = "Kerja bagus.";
            teksIndikator.color = Color.green;
        }

        tombolRestart.gameObject.SetActive(true);
        Button restartBtn = tombolRestart.GetComponent<Button>();
        restartBtn.onClick.RemoveAllListeners();
        restartBtn.onClick.AddListener(RestartKuis);
    }

    void RestartKuis()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
