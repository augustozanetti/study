
# Execute: 
- cd hyper\backend\Hyper.Web
- dotnet build  
- cd ..\Hyper.Infra
- dotnet ef database update
- cd ..\Hyper.Web
- dotnet run

# Abra outro terminal e execute  
- cd hyper\frontend\hyper  
- yarn  
- yarn start
- Acesse localhost:3000
