import { MongoClient } from 'mongodb';
import express from 'express';
const urlForMongo = 'mongodb://localhost:27017';
const wikiName = 'enwiki';
const wikiCollection = 'pages';
const app = express();


app.get('/wiki/:query', function(req, res){
    MongoClient.connect(urlForMongo, {useNewUrlParser: true } , (err, client) => {
        console.log('connected');
        let result = client.db(wikiName).collection(wikiCollection).find({title: {$regex: req.params.query, $options: 'i'}}).toArray().then((collection) => {
            client.close();
            console.log('closing connection');
            res.json(collection);
        }).catch((err) => {
            console.log(err);
            res.send(err);
        });
    })
});



app.listen(8080, function(){
    console.log('Listening on port 8080');
});