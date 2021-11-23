# McapCyinWS
Web Service para pruebas de metodo GET y POST de Http para la materia ciberinfraestructura de la Maestría en Computo Aplicado Univerisdad de Guadalajara 2021-B


### Probar el Web Service con:
##POST
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"name":"Pedro","cargo":"Contador"}' \
 http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/
 
 curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"name":"Pedro","cargos":"Contador"}' \
 http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/
 
 curl --header "Content-Type: application/json" \
  --request POST \
  --data '{}' \
 http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/

##GET
[http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/100](http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/100)

[http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/1](http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/1)

[http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/](http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/)

[http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/SearchByName/?name=Carl](http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/SearchByName/?name=Carl)

[http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/SearchByName/?name=Carlos](http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/SearchByName/?name=Carlos) 

[http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/SearchByName/?name=Ivan](http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/SearchByName/?name=Ivan) 

[http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/](http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catpersonal/)
