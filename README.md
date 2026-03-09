> [See in spanish/Ver en español](https://github.com/LuisMiSanVe/LangToSQL/blob/main/README.es.md)

<img src="https://github.com/LuisMiSanVe/LuisMiSanVe/blob/main/Resources/LangToSQL/LangToSQL_banner.png" style="width: 100%; height: auto;" alt="LangToSQL Banner">

# <img src="https://github.com/LuisMiSanVe/LangToSQL/blob/main/AiPostgreWinForms/Resources/icon.ico" width="40" alt="LangToSQL Logo"> LangToSQL | AI-Assisted WinForms for PostgreSQL
[![image](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://dotnet.microsoft.com/en-us/languages/csharp)
[![image](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet)
[![image](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![image](https://img.shields.io/badge/json-5E5C5C?style=for-the-badge&logo=json&logoColor=white)](https://www.newtonsoft.com/json)
[![image](https://img.shields.io/badge/Google%20Gemini-8E75B2?style=for-the-badge&logo=googlegemini&logoColor=white)](https://aistudio.google.com/app/apikey)
[![image](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)](https://visualstudio.microsoft.com/)

>[!NOTE]
> Check out other versions of this program:
>- [REST API](https://github.com/LuisMiSanVe/LangToSQL_API/tree/main) 
>- [ChatBot](https://github.com/LuisMiSanVe/LangToSQL_ChatBot/tree/main)
>- [NuGet](https://github.com/LuisMiSanVe/LangToSQL_NuGet/tree/main)
>- [Android](https://github.com/LuisMiSanVe/GeminiLiteSQL/tree/main)
>- [LLM](https://github.com/LuisMiSanVe/LangToSQL_LLM/tree/main)

This WinForms program uses Google's AI 'Gemini 2.0 Flash' to make queries to PostgreSQL databases.  
The AI interprets natural language into SQL queries using one method, with its pros and cons.

## 📋 Prerequisites
To make this program work, you'll need a PostgreSQL Server and a Gemini API Key.

> [!NOTE]  
> I will be using pgAdmin to build the PostgreSQL Server.

## 🛠️ Setup
If you don't have it, download [pgAdmin 4 from the official website](https://www.pgadmin.org/download/).  
Now, create the PostgreSQL Server and set up a database with a few tables and insert values.

You can use either a Gemini API key or use a local LLM Server, I recommend using [LM Studio](https://lmstudio.ai/).

Next, obtain your Gemini API Key by visiting [Google AI Studio](https://aistudio.google.com/app/apikey). Ensure you are logged into your Google account, then press the blue button that says 'Create API key' and follow the steps to set up your Google Cloud Project and retrieve your API key. **Make sure to save it in a safe place**.  
Google allows free use of this API without adding billing information, but there are some limitations.

In Google AI Studio, you can monitor the AI's usage by clicking 'View usage data' in the 'Plan' column where your projects are displayed. I recommend monitoring the 'Quota and system limits' tab and sorting by 'actual usage percentage,' as it provides further more detailed information.

You now have everything needed to make the program work.  
Simply put that data you just got into the setting windows in the program.

## 📖 About the WinForms program
The interface have a few buttons, being <img src="https://github.com/LuisMiSanVe/LangToSQL/blob/main/AiPostgreWinForms/Resources/key.png" width="20" alt="API Key Settings"> and <img src="https://github.com/LuisMiSanVe/LangToSQL/blob/main/AiPostgreWinForms/Resources/db.png" width="20" alt="Database Settings"> setting windows, for configuring the API Key and the database respectively and <img src="https://github.com/LuisMiSanVe/LangToSQL/blob/main/AiPostgreWinForms/Resources/show.png" width="20" alt="Show SQL">/<img src="https://github.com/LuisMiSanVe/LangToSQL/blob/main/AiPostgreWinForms/Resources/hide.png" width="20" alt="Hide SQL"> to show or hide the AI's generated query.

The <img src="https://github.com/LuisMiSanVe/LangToSQL/blob/main/AiPostgreWinForms/Resources/map.png" width="20" alt="Map DB"> button displays a Mapped Databases Manager, where you can Map into JSON any database you want and select one for future requests to the AI. 

These Mapped Databases are stored in your drive so they will always be loaded when you start the program. 

Remember that the Mapped Databases are only used in the AI requests, so when you run a tweaked query, it will run on the configured PostgreSQL Server instead.

When you click 'Save' in the Database Settings Window or in the API Key Settings Window (if the 'Remember' box is checked) a file will be created in the internal folder of the program so the next time the program is started, all this data gets loaded automatically.
> [!NOTE]
> The API Key and DB data configuration files are encrypted using AES with a [Specific System Based Method](https://gist.github.com/LuisMiSanVe/6b3c53cbfc4fcd75d816377bb6eb06b5), where the AES Key is made with your system's specs, so if any unwanted person were to steal those files, they could not be decrypted, keeping your sensitive data safe.

**[Natural Language to SQL Translation Method:](https://gist.github.com/LuisMiSanVe/2da8e2d932a06ef408b3ee8468d0d820)**  
This method maps the database structure into a JSON that Gemini analyzes ([with this prompt](https://gist.github.com/LuisMiSanVe/b189c8920d2dcedf5fd46485f3403d51)) to create an SQL query, which is then run by the PostgreSQL Server, returning the requested data.  
Since this method does not map the database values, token usage is lower, and the data is more reliable since it directly comes from the PostgreSQL Server. However, it does not completely prevent AI-generated errors. Occasionally, the SQL query might fail due to non-existing columns, in which case you should check the generated query to detect the error.

## 🚀 Releases
The version will be released using these versioning policies:\
New major features and critical bug fixes will cause the immediate release of a new version, while other minor changes or fixes will wait one week since the time the change is introduced in the repository before being included in the new version, so that other potential changes can be added.
>[!NOTE]
>These potencial new changes will not increase the wait time for the new version beyond one week.

The version number will follow this format: \
\[Major Feature\].\[Minor Feature\].\[Bug Fixes\]

## 💻 Technologies Used
- Programming Language: [C#](https://dotnet.microsoft.com/en-us/languages/csharp)
- Framework: [.Net](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet) 8.0 Framework
- NuGet Packages:
  - [Npgsql](https://www.npgsql.org/) (8.0.5)
  - [RestSharp](https://restsharp.dev/) (112.1.0)
  - [Newtonsoft.Json](https://www.newtonsoft.com/json) (13.0.3)
  - [System.Management](https://learn.microsoft.com/es-es/dotnet/api/system.management?view=netframework-1.1) (9.0.1)
- Other:
  - [PostgreSQL](https://www.postgresql.org/) (16.3)
  - [pgAdmin 4](https://www.pgadmin.org/) (8.9)
  - [LM Studio](https://lmstudio.ai/)
  - Gemini API Key (2.0 Flash)
  - Loading screen design by [my wife](https://github.com/meowwan)
  - Images (Icons source, later retouched by me):
    - [FreeIcons](https://freeicons.io/)
    - [Depositphotos](https://depositphotos.com/vector/coarse-halftone-dots-pattern-gradient-in-vector-format-82396024.html)
  - [Microsoft Visual Studio Installer Projects 2022](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2022InstallerProjects) (2.0.1)
- Recommended IDE: [Visual Studio](https://visualstudio.microsoft.com/) 2022
