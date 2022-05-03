# Projet Dev

## Description
Développement d'une marketplace sur le principe de le bon coin.

## Techno
* posgreSQL (bdd)
* asp .NET (back)
* angular,html,tailwindcss (front)

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

