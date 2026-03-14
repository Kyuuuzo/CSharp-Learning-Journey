/*
 * =======================================================================
 * PROJECT  : CSharp-Learning-Journey
 * TOPIC    : Dynamic Collections
 * MODULE   : 01-Basic
 * AUTHOR   : Kyuuuzo
 * DATE     : 14 Maret 2026
 * * DESCRIPTION:
 * Modul ini mengeksplorasi penggunaan System.Collections.Generic, khususnya 
 * tipe data List<string> untuk manajemen memori dinamis. Fokus utama 
 * adalah implementasi metode .Add() untuk alokasi item, .Remove() untuk 
 * modifikasi data berbasis objek, serta penggunaan string.Join guna 
 * optimasi representasi visual koleksi. Program ini menggabungkan 
 * logika iterasi (for loop) dengan validasi kapasitas guna mensimulasikan 
 * sistem inventory yang stabil dan efisien.
 * =======================================================================
 */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int kapasitasTas = 8;
        var tas = new List<string>();
        bool apaBerpetualang = true;

        while (apaBerpetualang)
        {
            Console.Clear();
            Console.WriteLine($"|==-==-==-==-== Tas Anda ({tas.Count}/{kapasitasTas}) -==-==-==-==|\n\n" +
                $"Isi Tas: {string.Join(", ", tas)}\n\n" +
                $"Pilihan Anda:\n" +
                $"1. Tambah Item\n" +
                $"2. Hapus Item\n" +
                $"3. Lihat Isi Tas\n" +
                $"4. Keluar\n" +
                $"Pilihan: ");
            int pilihan;
            while (!int.TryParse(Console.ReadLine(), out pilihan) || pilihan < 1 || pilihan > 4)
            {
                Console.Write("Input tidak valid. Masukkan angka antara 1 dan 4: ");
            }
            switch (pilihan)
            {
                case 1:
                    if (tas.Count >= kapasitasTas)
                    {
                        Console.WriteLine("Tas sudah penuh! Hapus item terlebih dahulu.");
                    }
                    else
                    {
                        Console.Write("Masukkan nama item yang ingin ditambahkan: ");
                        string itemBaru = Console.ReadLine();
                        tas.Add(itemBaru);
                        Console.WriteLine($"Item '{itemBaru}' telah ditambahkan ke tas.");
                    }
                    break;
                case 2:
                    if (tas.Count == 0)
                    {
                        Console.WriteLine("Tas kosong! Tidak ada item untuk dihapus.");
                    }
                    else
                    {
                        Console.Write("Masukkan nama item yang ingin dihapus: ");
                        string itemHapus = Console.ReadLine();
                        if (tas.Remove(itemHapus))
                        {
                            Console.WriteLine($"Item '{itemHapus}' telah dihapus dari tas.");
                        }
                        else
                        {
                            Console.WriteLine($"Item '{itemHapus}' tidak ditemukan di tas.");
                        }
                    }
                    break;
                case 3:
                    if (tas.Count == 0)
                    {
                        Console.WriteLine("Tas kosong!");
                    }
                    else
                    {
                        for (int i = 0; i < tas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tas[i]}");
                        }
                    }
                    break;
                case 4:
                    apaBerpetualang = false;
                    Console.WriteLine("Petualangan berakhir! Waktunya pulang...");
                    break;
            }
        }
    }
}