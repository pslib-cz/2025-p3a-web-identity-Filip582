# Evidence vypité kávy

Na naší škole se pije káva. A to docela dost. Aby byl přehled, kdo z učitelů ji kolik vypil a kolik má zaplatit, napsal kdysi šikovný student jednoduchou aplikaci.
Učitel prostě napsal svoji zkratku a číslo kávovaru ve kterém si kávu připravuje a o zbytek se postarala aplikace.
Jenže přišla nová doba. Káva se pije stále víc a někteří učitelé vyplňují některé údaje špatně - píší svoji zkratku velkými písmeny, píší místo ni své celé jméno.
Máme dokonce i případy, kdy jsou v aplikaci napsaní i kolegové, kteří kávu vůbec nepijí.

Je tedy potřeba do celého systému vnést pořádek a přinutit uživatele se přihlašovat. A to je úkol pro Vás.

Vezměte tedy stávající aplikaci a rozšiřte ji o přihlašování uživatelů.

## Postup

1. **Instalace NuGet balíčků** - Doinstalujte do projektu chybějící balíčky (stejná verze jako ostatní EF Core balíčky):
2. **Vlastní třída uživatele** - Je-li to nutné, upravte existující soubor `Models/ApplicationUser.cs`. Třída rozšiřuje výchozího uživatele o jméno (vlastnost `Name`):
3. **Úprava ApplicationDbContext** - Změňte základní třídu `ApplicationDbContext`. Zajistěte, že migrace vytvoří i všechny Identity tabulky (uživatelé, role, …):
4. **Oboustranná vazba mezi uživatelem a šálkem** - Upravte model `CoffeeCup` tak, aby odkazoval na `ApplicationUser`. Navigační vlastnost se jmenuje `User`, cizí klíč `UserId` (dle konvencí)
5. **Migrace databáze** - Stávající databázi i migrace klidně smažte (ale nemusíte) a vytvořte nové, které zahrnují jak Identity tabulky, tak upravenou strukturu `CoffeeCup`:
6. **Konfigurace Identity v Program.cs** - Rozšiřte konfiguraci služeb o verzi, která:
   - zaregistruje Identity,
   - nastaví mírnější požadavky na heslo
7. **Seedování role a účtu Administrátora** - Administrátor musí v systému existovat dříve, než se k němu kdokoli přihlásí. Přidejte jeho seed do ApplicationDbContext nebo do `Program.cs`:
8. **Přihlašovací stránky** – Pomocí scaffoldingu vygenerujte stránky pro přihlášení a registraci. Vyberte alespoň `Account\Login`, `Account\Logout` a `Account\Register`.
   - Viz odkaz [ASP.NET Identity (scaffold)](https://pslib.sharepoint.com/sites/studium/web/SitePages/ASP.NET-Identity-Scaffold.aspx).
9. **Login/Logout v záhlaví** - Vytvořte soubor `Pages/Shared/_LoginPartial.cshtml` s odkazy na přihlašovací a registrační stránky a přídejte ho přes _partial do navigace v `Pages/Shared/_Layout.cshtml`:
10. **Ochrana stránky Create** - Stránka pro přidání šálku musí být přístupná jen přihlášeným uživatelům. 
    - Při ukládání nového záznamu přiřaďte přihlášeného uživatele:
11. **Stránky pro Administrátora** - Vytvořte složku `Pages/Admin/` a v ní dvě stránky:
    - `Users.cshtml` – seznam všech uživatelů s odkazem na detail šálků každého z nich (chraňte pomocí Admin Policy)
    - `UserCups.cshtml` – seznam šálků konkrétního uživatele (parametr `userId` v URL)

## Fragmenty kódu

```razor
@using Microsoft.AspNetCore.Identity
@using CoffeeRecordsIdentity.Models
@inject SignInManager<ApplicationUser> SignInManager
@inject UserManager<ApplicationUser> UserManager

<ul class="navbar-nav">
@if (SignInManager.IsSignedIn(User))
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="Identity" asp-page="/Account/Manage/Index" title="Manage">Hello @User.Identity?.Name!</a>
    </li>
    <li class="nav-item">
        <form class="form-inline" asp-area="Identity" asp-page="/Account/Logout" asp-route-returnUrl="@Url.Page("/", new { area = "" })" method="post">
            <button type="submit" class="nav-link btn btn-link text-dark">Logout</button>
        </form>
    </li>
}
else
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="Identity" asp-page="/Account/Register">Register</a>
    </li>
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="Identity" asp-page="/Account/Login">Login</a>
    </li>
}
</ul>
```

## Související informace

[ASP.NET Identity Autorizace](https://pslib.sharepoint.com/sites/studium/web/SitePages/ASP.NET-Identity-Authorization.aspx)

[ASP.NET Identity (scaffold)](https://pslib.sharepoint.com/sites/studium/web/SitePages/ASP.NET-Identity-Scaffold.aspx)

## Vložení části stránky z jiného souboru

Je možné, pokud nemá vlastní PageModel, pomocí Razor Pages syntaxe:

```razor
<partial name="_LoginPartial" />
```
