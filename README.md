# PetFindMe Shop

## Connect to the Database

### NOTE!
### If your are using Docker, change the Docker Configuraton
### If your are using Windows Authentication, change the Windows Authentication Configuraton

## There are 3 types of users

### Customer - Can add producuts to Favourites, can buy products and can see alll his orders

### Shop Manager - Can create shops, add products and see all orders of them

### Admin - Have full access over the application

## Seeded Users

### Customer
email: `customer@abv.bg`<br>
password: `customer123`

### Shop Manager
email: `manager@abv.bg`<br>
password: `manager123`

### Admin
email: `admin@petfindmeshop.bg`<br>
password: `admin123`

## Create Migration
`Add-Migration CreateAndSeedDb -OutputDir Migrations`

## Update Database
`Update-Database`

## Remove last applied Migration
`Remove-Migration`

## Revert all Migrations
`Update-Database 0`