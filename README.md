# Projet Dev

## Description
Développement d'une marketplace sur le principe de le bon coin.

## Techno
* posgreSQL (bdd)
* asp .NET (back)
* html,Bootstrap (front)

## Fonctionnalités 

* [ ] client (9 points)
    * [ ] créer son compte | BDD : 
        * table user
        
            | id       | nom      | prénom   | mail     | mdp      | localisation |
            | -------- | -------- | -------- | -------- | -------- | ------------ |
            |          |          |          |          |          |              |
	* [ ] ajouter un article a son panier | BDD : 
        * table panier
            | id user  | id article |
            | -------- | ---------- |
            |          |            |
            
    * [ ] login au site 
	* [ ] modifier son profil
	* [ ] page d'articles globaux (par catégories, date, ...)
	* [ ] chercher un article (catégorie, localisation, prix,...)
	* [ ] tchater un vendeur (tchat différé) | BDD : (3 points)
	    * table conversation
	    
        | id       | id user    | id marchand |
        | -------- | ---------- | ----------- |
        |          |            |             |
        * table messages

        | id conv  | message    | date        |
        | -------- | ---------- | ----------- |
        |          |            |             |
	* [ ] ajout au favoris
	    * table favoris

	    | id user  | id article |
        | -------- | ---------- |
        |          |            |

* [ ] marchand : client (4 points)
	* [ ] créer ses articles
	* [ ] personnaliser sa page d'articles
	* [ ] créer sa "boutique" (son profil)

* [ ] admin : (5 points)
    * modifier / supprimer les comptes utilisateurs
    * modifier / supprimer les articles
    * modifier / supprimer les pages de ventes de marchands
    * promote un compte client en marchand
    * promote un compte client / marchand en admin

* [ ] article : (3 points)
    * [ ] article | BDD : 
        * table articles
        
        | id       | id marchand | nom      | prix     | description | catégories | localisation |
        | -------- | ----------- | -------- | -------- | ----------- | ---------- | ------------ |
        |          |             |          |          |             |            |              |

## Installation et Set up

* Clonnez le repository et ouvrez le dans VS code.
* Installez .NET 6 (https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
* Installez docker (https://www.docker.com/products/docker-desktop/).
* Ouvrez un terminal et tapez "docker-compose up --build -d" pour démarrer le container de la base de donnée. 
* Pour accéder à la database :
    * Dans le même terminal que précédemment, tapez "docker ps".
    * Copiez le CONTAINER ID.
    * Puis tapez "docker inspect CONTAINER ID" en remplaçant par l'id copié.
    * Tout en bas dans "Networks" copiez l' "IPAddress".
    * Ouvrez un navigateur en localhost:5050.
    * Connectez vous avec les identifants "admin@admin.com" et "root".
    * Ajoutez un nouveau serveur depuis le Dashboard.
    * Donnez le nom que vous voulez.
    * Puis dans "Connection", tapez l'ip copié plus haut dans la case "Hostname".
    * Enfin remplacez le "Username" 'admin' par 'root' et tapez le "Password" 'root'.
    * Cliquez sur "Save".
* Rendez-vous dans le fichier "Program.cs" et décommentez la ligne 50, il s'agit du seeding de la base de donnée.
* Dans un nouveau terminal, tapez "dotnet run" puis arretez l'application.
* Retournez dans le fichier "Program.cs" et recommentez la ligne 50.
* Vous pouvez de nouveau tapez "dotnet run" pour démarrer l'application.
* Pour ajouter le premier administrateur à l'application :
    * Créez un premier utilisateur.
    * Accedez à l'interface pg admin dans un navigateur comme expliqué plus haut.
    * A gauche déscendez dans l'arborescence "Servers/nomDonnéLorsDeLaConnexion/Database/app_db/Schemas/public".
    * Faites un clic droit sur l'onglet "Tables" dans l'arborescence.
    * Puis Sélectionnez "Query Tool" en bas du petit menu.
    * Dans la zone de text de l'onglet apparu au millieu de l'écran, tapez "INSERT INTO "identityuserrole<int>" VALUES('1','1'); DELETE FROM "identityuserrole<int>" WHERE (role_id = '2');".
    * Ensuite cliquez sur le bouton "Execute" dans la barre d'outil au dessus de la zone de text.
    * Retournez sur l'application, déconnectez vous puis reconnectez vous et vous devriez avoir les permissions administrateurs.