# Bannerlord Mod for Better Smithing
[![GitHub release](https://img.shields.io/github/v/release/thiagomsr20/Bannerlord-BetterSmithing)](https://github.com/thiagomsr20/Bannerlord-BetterSmithing/releases)
[![License](https://img.shields.io/github/license/thiagomsr20/Bannerlord-BetterSmithing)](https://github.com/thiagomsr20/Bannerlord-BetterSmithing/blob/main/LICENSE)

![Bannerlord](https://i.redd.it/knctfjvce4q41.png)

## 📜 Introduction
I have always loved medieval-themed games, and *Mount & Blade: Warband* was the best game I have ever played in this genre. Its successor, *Mount & Blade: Bannerlord*, has quickly become one of my favorites. 

One of the many mechanics in the game is the **Smithing system**, which allows you to craft weapons, refine metals, or melt down weapons obtained as loot or purchased from city markets.

## ⚔️ The Problem
When refining or melting a small number of items, clicking once per item to execute the action is not a big deal. However, the issue arises when you need to **refining or melting a large number of items**. The game does not offer a functionality to hold **CTRL + click** to execute multiple actions at once (which, honestly, it should, as this is a basic feature).

This problem made my gameplay frustrating, as my character played the role of a blacksmith, meaning I frequently refined or melted down many items to extract materials. 

## 🛠️ The Solution
To solve this issue, I researched mod development for the game and discovered that it uses my favorite language, **C#**. Motivated by this, I started learning how to create a mod and publish it on Steam, making my gameplay experience much smoother and more enjoyable.

By Searching for how to create a mod, I learned a new .NET concept, Reflection, in simple terms, Reflection is the capability of an external program to read, write, and be understood by another program in runtime. So I implemented a lib called [Harmony](https://docs.bannerlordmodding.lt/modding/harmony/#patching-game-models), which allows me to read and override the implementations of all the methods called in the game.

---

## ✨ Features
- ✅ **Refine many** materials at once
- ✅ **Batch melting** of weapons
- ✅ **No energy cost to Smithing**

## 📥 Installation
1. Download the latest release from the [Releases Page](https://github.com/yourusername/bannerlord-batch-mod/releases).
2. Extract the files into the `Modules` folder in your Bannerlord installation directory.
3. Enable the mod in the game launcher.

**Or you can subscribe at the steam** [Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=3435494593).

## 🤝 Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

---
Stay tuned for updates and improvements! 🚀

![Bannerlord](https://www.pcgamesn.com/wp-content/sites/pcgamesn/2019/03/mount-and-blade-2-bannerlord-closed-beta.jpg)
