# Différences syntaxiques principales entre MySQL et SQL Server

| **Aspect**                     | **MySQL**                                                  | **SQL Server**                                           |
|--------------------------------|-----------------------------------------------------------|---------------------------------------------------------|
| **Délimiteurs d'identifiants** | Backticks `` `table` ``                                    | Crochets `[table]`                                      |
| **Concaténation**              | `CONCAT(col1, col2)`                                       | `col1 + col2`                                           |
| **Type d'auto-incrément**      | `AUTO_INCREMENT`                                           | `IDENTITY(1,1)`                                         |
| **Limitation des résultats**   | `LIMIT 10`                                                | `TOP 10` ou `OFFSET ... FETCH`                         |
| **Gestion des dates**          | `NOW()` pour la date/heure actuelle                       | `GETDATE()` ou `SYSDATETIME()`                         |
| **Commentaire**                | `-- Commentaire` ou `# Commentaire`                       | `-- Commentaire`                                        |
| **Alias de colonnes**          | `SELECT col AS alias` ou `SELECT col alias`               | `SELECT col AS alias`                                   |
| **Détection des NULLs**        | `IFNULL(expr, value)`                                     | `ISNULL(expr, value)`                                   |
| **Requêtes conditionnelles**   | `IF(condition, true_val, false_val)`                      | `CASE WHEN condition THEN true_val ELSE false_val END` |
| **Transactions explicites**    | `START TRANSACTION ... COMMIT/ROLLBACK`                   | `BEGIN TRAN ... COMMIT/ROLLBACK`                       |
| **Mode strict**                | Optionnel (`sql_mode` avec `STRICT_TRANS_TABLES`)         | Par défaut plus strict sur la cohérence des types      |



## Types de données

| **Type MySQL**          | **Équivalent SQL Server**        | **Remarques**                                         |
|--------------------------|----------------------------------|------------------------------------------------------|
| `TINYINT`               | `TINYINT`                       | Identique (valeurs de 0 à 255 en UNSIGNED)           |
| `SMALLINT`              | `SMALLINT`                      | Identique                                            |
| `MEDIUMINT`             | *(Non disponible)*              | Proche de `INT` avec une taille intermédiaire        |
| `INT` ou `INTEGER`      | `INT` ou `INTEGER`              | Identique                                            |
| `BIGINT`                | `BIGINT`                        | Identique                                            |
| `DECIMAL` ou `NUMERIC`  | `DECIMAL` ou `NUMERIC`          | Identique                                            |
| `FLOAT`                 | `REAL` ou `FLOAT`               | Valeurs similaires, mais taille des flottants peut différer |
| `DOUBLE`                | `FLOAT`                        | Équivalent approximatif en précision                |
| `BIT`                   | `BIT`                          | Identique                                            |
| **Chaînes de caractères**|                                  |                                                      |
| `CHAR(n)`               | `CHAR(n)`                      | Identique                                            |
| `VARCHAR(n)`            | `VARCHAR(n)`                   | Identique                                            |
| `TINYTEXT`              | *(Non disponible)*             | Proche de `VARCHAR(n)` avec une petite limite        |
| `TEXT`                  | `VARCHAR(MAX)`                 | SQL Server ne supporte pas `TEXT` nativement        |
| `MEDIUMTEXT`/`LONGTEXT` | `VARCHAR(MAX)`                 | Équivalent approximatif                             |
| **Dates et heures**     |                                  |                                                      |
| `DATE`                  | `DATE`                         | Identique                                            |
| `DATETIME`              | `DATETIME`                     | Identique                                            |
| `TIMESTAMP`             | `DATETIME` ou `ROWVERSION`     | `ROWVERSION` ne stocke que des horodatages          |
| `TIME`                  | `TIME`                         | Identique                                            |
| `YEAR`                  | *(Non disponible)*             | Utiliser un `SMALLINT` ou une contrainte pour l'année |
| **Autres types**        |                                  |                                                      |
| `ENUM`                  | *(Non disponible)*             | Simuler avec une colonne `VARCHAR` et une contrainte |
| `SET`                   | *(Non disponible)*             | Simuler avec une table de relation                  |
| `BLOB`                  | `VARBINARY(MAX)`               | Identique en usage                                   |
| `TINYBLOB`/`MEDIUMBLOB`/`LONGBLOB` | `VARBINARY(MAX)`  | SQL Server utilise une approche unique pour les BLOBs |

