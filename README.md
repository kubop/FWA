1. vytvorit vlastnu db 
	- ✅ user (minimalne userId, login, password a addressId fieldy)
	- ✅ address - addressId, street, number, city, zip 

2. ✅ ak treba vytvor si view aky budes potrebovat

3. ✅ nepouzivaj FK

4. ✅ asp.net core mvc application

5. ✅ pouzit generator a yamo

6. ❌ spravit login/logout (pripadne pridat login aj cez google/microsoft - toto nechaj na koniec)

7. manazment nad user tabulkou
	- ✅ grid view kde budu zobrazene vsetky recordy (adresu zobrazit vo formate "street number, zip city", ak bude mat nejaky user adresu ktora neexistuje, namiesto popisu zobrazit jej id), 
		- ✅ moznost mazat
		- ✅ moznost zoradit podla vsetkych fieldov asc/desc (toto nechaj na koniec)

	- ✅ edit view kde sa budu dat menit vsetky hodnoty
		- ✅ adresa ako combo (ak bude mat user nasetovanu neexistujucu adresu, malo by sa jej id korektne zobrazit v combe)
		- ✅ zvaz co das povinne a co nie, pripadne dalsie validacie

8. manazment nad address tabulkou
	- ✅ grid podobne, + zobrazit pocet userov ktory maju priradenu danu adresu
	- ✅ edit podobne
