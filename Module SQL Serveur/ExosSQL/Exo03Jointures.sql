

--INNER JOIN :
--S�lectionnez les noms et pr�noms des clients ainsi que les d�tails
--de leurs achats (si disponibles).
--SELECT  first_name , last_name, purchases.*
--FROM [Clients] 
--INNER JOIN Purchases 
--ON Clients.id = Purchases.client_id


--LEFT JOIN :
--S�lectionnez tous les clients et les d�tails de leurs achats s'ils ont
--effectu� des achats, sinon affichez les colonnes des achats avec des
--valeurs NULL.
--SELECT  Clients.* , Purchases.*
--FROM [Clients] 
--LEFT JOIN Purchases ON Clients.id = Purchases.client_id

--RIGHT JOIN :
--S�lectionnez tous les achats et les d�tails des clients
--correspondants, m�me s'il n'y a pas de correspondance.
--SELECT   Purchases.* , Clients.*
--FROM [Clients] 
--RIGHT JOIN Purchases ON Clients.id = Purchases.client_id


--FULL JOIN :
--S�lectionnez tous les clients et tous les achats, en affichant les
--d�tails des clients m�me s'ils n'ont pas effectu� d'achats, et vice
--versa.
--SELECT   Purchases.* , Clients.*
--FROM [Clients] 
--FULL JOIN Purchases ON Clients.id = Purchases.client_id

 