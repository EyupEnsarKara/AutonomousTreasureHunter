# Autonomous Treasure Hunter | Otonom Hazine Avcısı

## English

### Introduction
"Autonomous Treasure Hunter" is a 2D game developed using C# and Windows Forms. The game's core objective is to navigate an autonomous character through a randomly generated map to collect treasures. The game is designed to challenge and enhance problem-solving skills, applying object-oriented programming concepts and data structures effectively. The implementation of the A* pathfinding algorithm ensures the character can find the shortest route to collect all treasures while avoiding obstacles.

### Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation-for-develop)
- [Usage](#usage)
- [Game Mechanics](#game-mechanics)
- [Dependencies](#dependencies)
- [Contributors](#contributors)

### Features
- **Dynamic Game Environment**: Randomly generated maps with treasures placed at different locations.
- **Obstacle System**: 
  - **Static Obstacles**: Trees, rocks, walls, and mountains that must be avoided.
  - **Dynamic Obstacles**: Moving obstacles like birds and bees that require strategic navigation.
- **A* Pathfinding Algorithm**: Efficient route calculation for the autonomous character to collect treasures optimally.
- **Interactive UI**: A graphical user interface that updates in real-time to show the character's progress and the dynamic environment.
- **Customizable Settings**: Different parameters of the game, like map size and obstacle density, can be adjusted.
- **Adjustable Speed**: Players can change the simulation speed during gameplay.

### Installation - For Developers
Clone the repository and open the project in Visual Studio. You can run the game by building the solution and starting the application. Make sure you have the necessary dependencies installed.

```
git clone https://github.com/yourusername/Autonomous-Treasure-Hunter.git
```

### Installation - For Users
Download the `AutonomousTreasureHunter_v0.0.1.zip` file from the release section and extract it. Run the `AutonomousTreasureHunter.exe` file to start the game.

### Usage
1. **Starting the Game**: Run the application to start the game. You will see the game window with the map and the autonomous character.				
2. **Game Objective**: The objective is to collect all treasures on the map by navigating the character through obstacles.
3. **Character Movement**: The character moves autonomously using the A* pathfinding algorithm to collect treasures.
4. **Game Progress**: The game will end when all treasures are collected, and the character will return to the starting point.
5. **Speed Control**: Customize speed with numpad keys:
   - `1`: Slow
   - `2`: Normal
   - `3`: Fast
   - `U`: Maximum speed

### Game Mechanics
- The character autonomously navigates using the A* algorithm
- The map is randomly generated with various obstacles
- Static obstacles remain in place while dynamic obstacles move around the map
- Treasures are placed randomly across the map
- The character must find the optimal path to collect all treasures and return to start

### Dependencies
- .NET Framework
- Windows Forms

### Contributors
- Eyüp Ensar Kara (eyupensarkara0@gmail.com)
- Yunus Hanifi Öztürk (oyunushanifi@gmail.com)

---

## Türkçe

### Giriş
"Otonom Hazine Avcısı", C# ve Windows Forms kullanılarak geliştirilen 2 boyutlu bir oyundur. Oyunun temel amacı, rastgele oluşturulan bir haritada otonom bir karakteri engellere takılmadan hazineleri toplamak için yönlendirmektir. Oyun, nesne yönelimli programlama kavramlarını ve veri yapılarını etkili bir şekilde uygulayarak problem çözme becerilerini geliştirmek üzere tasarlanmıştır. A* yol bulma algoritmasının uygulanması, karakterin engelleri aşarak tüm hazineleri toplamak için en kısa rotayı bulmasını sağlar.

### İçindekiler
- [Giriş](#giriş)
- [Özellikler](#özellikler)
- [Kurulum](#kurulum---geliştiriciler-için)
- [Kullanım](#kullanım)
- [Oyun Mekanikleri](#oyun-mekanikleri)
- [Bağımlılıklar](#bağımlılıklar)
- [Katkıda Bulunanlar](#katkıda-bulunanlar)

### Özellikler
- **Dinamik Oyun Ortamı**: Farklı konumlara yerleştirilmiş hazinelerle rastgele oluşturulan haritalar.
- **Engel Sistemi**: 
  - **Statik Engeller**: Ağaçlar, kayalar, duvarlar ve dağlar gibi kaçınılması gereken engeller.
  - **Dinamik Engeller**: Kuşlar ve arılar gibi stratejik navigasyon gerektiren hareketli engeller.
- **A* Yol Bulma Algoritması**: Otonom karakterin hazineleri en uygun şekilde toplaması için verimli rota hesaplaması.
- **Etkileşimli Kullanıcı Arayüzü**: Karakterin ilerlemesini ve dinamik ortamı gerçek zamanlı olarak gösteren grafiksel kullanıcı arayüzü.
- **Özelleştirilebilir Ayarlar**: Harita boyutu ve engel yoğunluğu gibi oyunun farklı parametreleri ayarlanabilir.
- **Ayarlanabilir Hız**: Oyuncular oyun sırasında simülasyon hızını değiştirebilir.

### Kurulum - Geliştiriciler İçin
Depoyu klonlayın ve projeyi Visual Studio'da açın. Çözümü derleyerek ve uygulamayı başlatarak oyunu çalıştırabilirsiniz. Gerekli bağımlılıkların yüklü olduğundan emin olun.

```
git clone https://github.com/kullaniciadi/Autonomous-Treasure-Hunter.git
```

### Kurulum - Kullanıcılar İçin
Sürüm bölümünden `AutonomousTreasureHunter_v0.0.1.zip` dosyasını indirin ve çıkarın. Oyunu başlatmak için `AutonomousTreasureHunter.exe` dosyasını çalıştırın.

### Kullanım
1. **Oyunu Başlatma**: Oyunu başlatmak için uygulamayı çalıştırın. Harita ve otonom karakter ile oyun penceresini göreceksiniz.
2. **Oyun Amacı**: Amaç, karakteri engeller arasında yönlendirerek haritadaki tüm hazineleri toplamaktır.
3. **Karakter Hareketi**: Karakter, hazineleri toplamak için A* yol bulma algoritmasını kullanarak otonom olarak hareket eder.
4. **Oyun İlerlemesi**: Tüm hazineler toplandığında oyun sona erer ve karakter başlangıç noktasına geri döner.
5. **Hız Kontrolü**: Numpad tuşlarıyla hızı özelleştirin:
   - `1`: Yavaş
   - `2`: Normal
   - `3`: Hızlı
   - `U`: Maksimum hız

### Oyun Mekanikleri
- Karakter A* algoritmasını kullanarak otonom olarak gezinir
- Harita çeşitli engellerle rastgele oluşturulur
- Statik engeller yerinde kalırken dinamik engeller harita üzerinde hareket eder
- Hazineler harita üzerine rastgele yerleştirilir
- Karakter tüm hazineleri toplamak ve başlangıca dönmek için en uygun yolu bulmalıdır

### Bağımlılıklar
- .NET Framework
- Windows Forms

### Katkıda Bulunanlar
- Eyüp Ensar Kara (eyupensarkara0@gmail.com)
- Yunus Hanifi Öztürk (oyunushanifi@gmail.com)
