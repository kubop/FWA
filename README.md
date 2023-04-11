vytvorit vlastnu db 
✅ user (minimalne userId, login, password a addressId fieldy)
✅ address - addressId, street, number, city, zip 

✅ ak treba vytvor si view aky budes potrebovat

✅ nepouzivaj FK

✅ asp.net core mvc application

✅ pouzit generator a yamo

❌ spravit login/logout (pripadne pridat login aj cez google/microsoft - toto nechaj na koniec)

manazment nad user tabulkou 
        ✅ grid view kde budu zobrazene vsetky recordy (adresu zobrazit vo formate "street number, zip city", ak bude mat nejaky user adresu ktora neexistuje, namiesto popisu zobrazit jej id), 
        ✅ moznost mazat
        ❌ moznost zoradit podla vsetkych fieldov asc/desc (toto nechaj na koniec)
 
	❌ edit view kde sa budu dat menit vsetky hodnoty
        ✅ adresa ako combo (ak bude mat user nasetovanu neexistujucu adresu, malo by sa jej id korektne zobrazit v combe)
        ✅ zvaz co das povinne a co nie, pripadne dalsie validacie

manazment nad address tabulkou
	❌ grid podobne, + zobrazit pocet userov ktory maju priradenu danu adresu
	❌ edit podobne
    
