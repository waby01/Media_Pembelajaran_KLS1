using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Soal
{
    public string pertanyaan;
    public Sprite gambar;
    public string[] pilihanJawaban = new string[5]; // Menampung 5 jawaban
    public int jawabanBenarIndex; // Indeks dari jawaban yang benar (0-4)
}
