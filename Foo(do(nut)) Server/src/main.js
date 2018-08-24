import { MongoClient } from 'mongodb';
import express from 'express';
const urlForMongo = 'mongodb://localhost:27017';
const wikiName = 'enwiki';
const wikiCollection = 'pages';
const app = express();


app.get('/wiki/:query', function(req, res){
    MongoClient.connect(urlForMongo, {useNewUrlParser: true } , (err, client) => {
        let resultStream = client.db(wikiName).collection(wikiCollection).find({title: {$regex: req.params.query, $options: 'i'}}).limit(5).stream();
        res.writeHead(200, { 'Content-Type': 'application/json'});
        console.log(req.ip);
        res.write('[');
        resultStream.on('data', (data) => {
            res.write(JSON.stringify(data));
            res.write(',');
        });

        resultStream.on('end', () => {
            res.write(']');
            res.end();
            console.log("closed");
        });
    });
});

app.get('/wiki/food', function(req, res){
    MongoClient.connect(urlForMongo, {useNewUrlParser: true } , (err, client) => {
        let resultStream = client.db(wikiName).collection(wikiCollection).find({title: {$regex: 'food', $options: 'i'}}).limit(5).stream();
        res.writeHead(200, { 'Content-Type': 'application/json'});
        console.log(req.ip);
        res.write('[');
        resultStream.on('data', (data) => {
            res.write(JSON.stringify(data));
            res.write(',');
        });

        resultStream.on('end', () => {
            res.write(']');
            res.end();
            console.log("closed");
        });
    });
});
app.get('wiki/food/:query', function(req, res){
    MongoClient.connect(urlForMongo, {useNewUrlParser: true } , (err, client) => {
        let resultStream = client.db(wikiName).collection(wikiCollection).find({title: {$regex: `food ${req.params.query}`, $options: 'i'}}).limit(5).stream();
        res.writeHead(200, { 'Content-Type': 'application/json'});
        console.log(req.ip);
        resultStream.on('data', (data) => {
            res.write(JSON.stringify(data));
        });

        resultStream.on('end', () => {
            res.end();
            console.log("closed");
        });
    });
});

app.listen(8080, function(){
    console.log('Listening on port 8080');
});