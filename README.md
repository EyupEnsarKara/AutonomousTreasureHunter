# 🎮 Otonom Hazine Avcısı | Autonomous Treasure Hunter

C# ve Windows Forms kullanılarak geliştirilmiş 2D otonom oyun. Karakter, A* yol bulma algoritması kullanarak rastgele oluşturulan haritada hazineleri toplar.

---

## 📋 İçindekiler

- [Giriş](#giriş)
- [Özellikler](#özellikler)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Oyun Mekanikleri](#oyun-mekanikleri)
- [Kontroller](#kontroller)
- [Gereksinimler](#gereksinimler)

---

## 🎯 Giriş

Otonom Hazine Avcısı, oyuncunun bir karakteri manuel olarak kontrol etmek yerine, karakterin A* algoritması kullanarak otomatik olarak haritadaki tüm hazineleri topladığı bir simülasyon oyunudur. Oyun, rastgele oluşturulan haritalar, çeşitli engeller ve farklı değerdeki hazineler sunar.

---

## ✨ Özellikler

### 🗺️ Dinamik Harita Sistemi
- Rastgele oluşturulan haritalar
- Özelleştirilebilir harita boyutu
- Yaz ve kış temalı bölgeler

### 🚧 Engel Sistemi
- **Statik Engeller**: Ağaç, kaya, duvar ve dağ gibi sabit engeller
- **Dinamik Engeller**: Kuş ve arı gibi hareketli engeller

### 💎 Hazine Sistemi
- Farklı değerde hazineler (Bakır, Gümüş, Altın, Zümrüt)
- Rastgele yerleştirilen hazine konumları

### 🤖 Otonom Navigasyon
- A* yol bulma algoritması ile optimal rota hesaplama
- Otomatik engel algılama ve kaçınma
- Sis (fog of war) mekaniği

### ⚙️ Özelleştirilebilir Ayarlar
- Harita boyutu seçimi
- Simülasyon hızı kontrolü
- Gerçek zamanlı görselleştirme

---

## 📦 Kurulum

### Geliştiriciler İçin

1. Projeyi klonlayın:
```bash
git clone https://github.com/yourusername/Autonomous-Treasure-Hunter.git
```

2. Visual Studio'da projeyi açın

3. Gerekli bağımlılıkların yüklü olduğundan emin olun

4. Projeyi derleyin ve çalıştırın

### Kullanıcılar İçin

1. Sürümler bölümünden en son sürümü indirin
2. ZIP dosyasını çıkarın
3. `AutonomousTreasureHunter.exe` dosyasını çalıştırın

---

## 🎮 Kullanım

### Oyunu Başlatma

1. Uygulamayı çalıştırın
2. Harita boyutunu girin (örneğin: 50, 100, 200)
3. "Başlat" butonuna tıklayın
4. Oyun otomatik olarak başlar

### Oyun Akışı

- Karakter otomatik olarak haritayı keşfetmeye başlar
- Yakındaki hazineler algılandığında karakter onlara doğru hareket eder
- Tüm hazineler toplandığında oyun sona erer
- Karakter başlangıç noktasına geri döner

---

## 🎲 Oyun Mekanikleri

### Karakter Hareketi
- Karakter A* algoritması kullanarak en kısa yolu hesaplar
- 7x7 alan içindeki hazineleri algılar
- Engelleri otomatik olarak tespit eder ve kaçınır

### Harita Keşfi
- Başlangıçta harita sisle kaplıdır
- Karakter hareket ettikçe çevresindeki alan açılır
- Keşfedilen engeller kaydedilir

### Hazine Toplama
- Karakter hazineye yaklaştığında otomatik olarak toplar
- Farklı hazineler farklı değerlere sahiptir
- Toplanan hazineler listede gösterilir

### Engel Türleri
- **Statik Engeller**: Sabit konumda duran engeller
- **Dinamik Engeller**: Belirli bir alanda hareket eden engeller

---

## ⌨️ Kontroller

### Hız Kontrolü
- **Numpad 1**: Yavaş hız
- **Numpad 2**: Normal hız
- **Numpad 3**: Hızlı
- **U Tuşu**: Maksimum hız

---

## 🔧 Gereksinimler

- **İşletim Sistemi**: Windows
- **.NET Framework**: Güncel sürüm
- **Windows Forms**: .NET Framework ile birlikte gelir

---

## 📝 Notlar

- Harita boyutu ne kadar büyükse, oyun o kadar uzun sürer
- Dinamik engeller karakterin yolunu değiştirebilir
- Tüm hazineler toplanana kadar oyun devam eder

---

## 🌐 English

### Introduction

"Autonomous Treasure Hunter" is a 2D game developed using C# and Windows Forms. The game's core objective is to navigate an autonomous character through a randomly generated map to collect treasures. The character uses the A* pathfinding algorithm to find the shortest route while avoiding obstacles.

### Features

- **Dynamic Game Environment**: Randomly generated maps with treasures
- **Obstacle System**: Static (trees, rocks, walls, mountains) and dynamic (birds, bees) obstacles
- **A* Pathfinding Algorithm**: Efficient route calculation
- **Interactive UI**: Real-time visualization
- **Customizable Settings**: Adjustable map size and simulation speed

### Installation

**For Developers:**
```bash
git clone https://github.com/yourusername/Autonomous-Treasure-Hunter.git
```
Open in Visual Studio and build the solution.

**For Users:**
Download the latest release, extract, and run `AutonomousTreasureHunter.exe`.

### Usage

1. Run the application
2. Enter map size
3. Click "Start"
4. Watch the character autonomously collect treasures

### Controls

- **Numpad 1**: Slow speed
- **Numpad 2**: Normal speed
- **Numpad 3**: Fast speed
- **U Key**: Maximum speed

### Requirements

- Windows OS
- .NET Framework
- Windows Forms

---
