using System;

// Öğrenci düğümünü temsil eden sınıf
class öğrencidüğümü
{
    public int Öğrencino; // Öğrenci numarası
    public string İsim; // Öğrenci ismi
    public öğrencidüğümü Next; // Bir sonraki düğüme işaret eder

    // Yapıcı metod: Yeni bir öğrenci düğümü oluşturur
    public öğrencidüğümü(int öğrencino, string isim)
    {
        Öğrencino = öğrencino; // Öğrenci numarasını ayarlar
        İsim = isim; // İsim değerini ayarlar
        Next = null; // Başlangıçta bir sonraki düğüm yok
    }
}

// Dairesel öğrenci listesi sınıfı
class Daireselöğrencilist
{
    private öğrencidüğümü head = null; // Listenin başını tutar

    // Başa ekleme metodu
    public void Öneekle(int öğrencino, string isim)
    {
        öğrencidüğümü yenidüğüm = new öğrencidüğümü(öğrencino, isim); // Yeni düğüm oluştur
        if (head == null) // Eğer liste boşsa
        {
            head = yenidüğüm; // Yeni düğüm baş olur
            yenidüğüm.Next = head; // İlk düğüm kendine işaret eder
        }
        else
        {
            öğrencidüğümü temp = head; // Geçici bir değişken oluştur
            while (temp.Next != head) temp = temp.Next; // Son düğüme git
            temp.Next = yenidüğüm; // Son düğümün Next'ini yeni düğüme ayarla
            yenidüğüm.Next = head; // Yeni düğüm başı gösterir
            head = yenidüğüm; // Baş güncellenir
        }
    }

    // Sona ekleme metodu
    public void sonaekle(int öğrencino, string isim)
    {
        öğrencidüğümü yenidüğüm = new öğrencidüğümü(öğrencino, isim); // Yeni düğüm oluştur
        if (head == null) // Eğer liste boşsa
        {
            head = yenidüğüm; // Yeni düğüm baş olur
            yenidüğüm.Next = head; // İlk düğüm kendine işaret eder
        }
        else
        {
            öğrencidüğümü temp = head; // Geçici bir değişken oluştur
            while (temp.Next != head) temp = temp.Next; // Son düğüme git
            temp.Next = yenidüğüm; // Son düğümün Next'ini yeni düğüme ayarla
            yenidüğüm.Next = head; // Yeni düğüm başı gösterir
        }
    }

    // Belirli bir sıraya ekleme metodu
    public void sonraekle(int öğrencinosonra, int studentNo, string name)
    {
        öğrencidüğümü temp = head; // Geçici bir değişken oluştur
        if (temp == null) return; // Eğer liste boşsa, işlemi sonlandır

        do
        {
            if (temp.Öğrencino == öğrencinosonra) // Eğer mevcut düğüm aranan öğrenci numarasına eşitse
            {
                öğrencidüğümü yenidüğüm = new öğrencidüğümü(studentNo, name); // Yeni düğüm oluştur
                yenidüğüm.Next = temp.Next; // Yeni düğümün Next'ini mevcut düğümün Next'ine ayarla
                temp.Next = yenidüğüm; // Mevcut düğümün Next'ini yeni düğüme ayarla
                return; // İşlem tamamlandı, çık
            }
            temp = temp.Next; // Bir sonraki düğüme geç
        } while (temp != head); // Başlangıca gelene kadar devam et
        Console.WriteLine("Öğrenci bulunamadı."); // Öğrenci bulunamazsa mesaj ver
    }

    // Baştan silme metodu
    public void öndensil()
    {
        if (head == null) return; // Eğer liste boşsa, işlemi sonlandır
        if (head.Next == head) head = null; // Tek eleman varsa, başı null yap
        else
        {
            öğrencidüğümü temp = head; // Geçici bir değişken oluştur
            while (temp.Next != head) temp = temp.Next; // Son düğüme git
            temp.Next = head.Next; // Baş düğüm silinir
            head = head.Next; // Yeni baş güncellenir
        }
    }

    // Sondan silme metodu
    public void sondansil()
    {
        if (head == null) return; // Eğer liste boşsa, işlemi sonlandır
        if (head.Next == head) head = null; // Tek eleman varsa, başı null yap
        else
        {
            öğrencidüğümü temp = head; // Geçici bir değişken oluştur
            öğrencidüğümü prev = null; // Önceki düğüm için değişken
            while (temp.Next != head) // Son düğüme gelene kadar git
            {
                prev = temp; // Önceki düğümü güncelle
                temp = temp.Next; // Mevcut düğümü güncelle
            }
            prev.Next = head; // Son düğüm silinir
        }
    }

    // Belirli bir öğrenciyi silme metodu
    public void düğümüsil(int öğrencino)
    {
        if (head == null) return; // Eğer liste boşsa, işlemi sonlandır

        öğrencidüğümü temp = head, prev = null; // Geçici ve önceki düğüm değişkenleri
        do
        {
            if (temp.Öğrencino == öğrencino) // Eğer mevcut düğüm aranan öğrenci numarasına eşitse
            {
                if (prev != null)
                {
                    prev.Next = temp.Next; // Düğüm silinir
                }
                else // Baş düğüm siliniyorsa
                {
                    öndensil(); // Baştan silme işlemi
                }
                return; // İşlem tamamlandı, çık
            }
            prev = temp; // Önceki düğümü güncelle
            temp = temp.Next; // Mevcut düğümü güncelle
        } while (temp != head); // Başlangıca gelene kadar devam et
        Console.WriteLine("Öğrenci bulunamadı."); // Öğrenci bulunamazsa mesaj ver
    }

    // Listeyi yazdırma metodu
    public void listeyazdır()
    {
        if (head == null) return; // Eğer liste boşsa, işlemi sonlandır
        öğrencidüğümü temp = head; // Geçici bir değişken oluştur
        do
        {
            Console.WriteLine($"Numara: {temp.Öğrencino}, İsim: {temp.İsim}"); // Öğrenci bilgilerini yazdır
            temp = temp.Next; // Bir sonraki düğüme geç
        } while (temp != head); // Başlangıca gelene kadar devam et
        Console.WriteLine(); // Yeni bir satır ekle
    }
}

// Ana program sınıfı
class Program
{
    static void Main()
    {
        Daireselöğrencilist list = new Daireselöğrencilist(); // Yeni dairesel öğrenci listesi oluştur

        // Ekleme işlemleri
        list.sonaekle(1, "Ahmet"); // Sona Ahmet ekle
        list.sonaekle(2, "Mehmet"); // Sona Mehmet ekle
        list.Öneekle(0, "Ayşe"); // Başa Ayşe ekle
        list.sonraekle(1, 3, "Fatma"); // Ahmet'in ardından Fatma ekle
        Console.WriteLine("Öğrenci Listesi:"); // Liste başlığını yazdır
        list.listeyazdır(); // Öğrenci listesini yazdır

        // Silme işlemleri
        list.öndensil(); // Baştan silme
        Console.WriteLine("Baştan silme:"); // Baş silme başlığını yazdır
        list.listeyazdır(); // Güncel listeyi yazdır

        list.sondansil(); // Sondan silme
        Console.WriteLine("Sondan silme:"); // Son silme başlığını yazdır
        list.listeyazdır(); // Güncel listeyi yazdır

        list.düğümüsil(3); // Fatma'yı sil
        Console.WriteLine("Belirli öğrenci silme:"); // Belirli öğrenci silme başlığını yazdır
        list.listeyazdır(); // Güncel listeyi yazdır
    }
}
