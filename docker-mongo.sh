sudo docker container kill mongo-on-docker 
sudo docker container rm --force mongo-on-docker 
# sudo docker volume prune

# sudo docker run -d  --name mongo-on-docker  -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Root@Root@123 mongo
# sudo docker run  -it -d  --name mongo-on-docker  -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Root@Root@123 mongo
# sudo docker run  -it -d  --name mongo-on-docker  -p 27017:27017 -v /path/to/mongodb:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Root@Root@123 mongo 
sudo docker logs mongo-on-docker

sudo docker exec -it mongo-on-docker bash

# mongo admin -host localhost -port 27017 -u mongoadmin -p
# mongo admin -u mongoadmin -p  --port 27017
mongo admin -u mongoadmin -p -host localhost -port 27017


# mongo
# use admin;
# db.createUser(
#   {
#     user: 'mongoadmin',
#     pwd: 'Root@Root@123',
#     roles: [ { role: 'root', db: 'admin' } ]
#   }
# );

# ou
# db.createUser(
#   {
#     user: "root",
#     pwd: "pass123",
#     roles: [ { role: "userAdminAnyDatabase", db: "admin" }, "readWriteAnyDatabase" ]
#   }
# )
 
#  role:dbOwner,userAdminAnyDatabase,root