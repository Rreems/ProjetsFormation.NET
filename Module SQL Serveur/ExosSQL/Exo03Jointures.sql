

--INNER JOIN :
--Sélectionnez les noms et prénoms des clients ainsi que les détails
--de leurs achats (si disponibles).
--SELECT  first_name , last_name, purchases.*
--FROM [Clients] 
--INNER JOIN Purchases 
--ON Clients.id = Purchases.client_id


--LEFT JOIN :
--Sélectionnez tous les clients et les détails de leurs achats s'ils ont
--effectué des achats, sinon affichez les colonnes des achats avec des
--valeurs NULL.
--SELECT  Clients.* , Purchases.*
--FROM [Clients] 
--LEFT JOIN Purchases ON Clients.id = Purchases.client_id

--RIGHT JOIN :
--Sélectionnez tous les achats et les détails des clients
--correspondants, même s'il n'y a pas de correspondance.
--SELECT   Purchases.* , Clients.*
--FROM [Clients] 
--RIGHT JOIN Purchases ON Clients.id = Purchases.client_id


--FULL JOIN :
--Sélectionnez tous les clients et tous les achats, en affichant les
--détails des clients même s'ils n'ont pas effectué d'achats, et vice
--versa.
--SELECT   Purchases.* , Clients.*
--FROM [Clients] 
--FULL JOIN Purchases ON Clients.id = Purchases.client_id

 