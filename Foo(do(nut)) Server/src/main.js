import { MongoClient } from 'mongodb';
import express from 'express';
const urlForMongo = 'mongodb://localhost:27017';
const wikiName = 'enwiki';
const wikiCollection = 'pages';
const app = express();


app.get('/wiki/:query', function(req, res){
    MongoClient.connect(urlForMongo, {useNewUrlParser: true } , (err, client) => {
        let resultStream = client.db(wikiName).collection(wikiCollection).find({title: {$regex: req.params.query, $options: 'i'}}).stream();
        res.writeHead(200, { 'Content-Type': 'application/json'});
        console.log(req.ip);
        res.write('[');
        let first = true;
        resultStream.on('data', (data) => {
            if(first){
                first = false;
            }else {
                res.write(',');
            }
            res.write(JSON.stringify(data));
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
        let resultStream = client.db(wikiName).collection(wikiCollection).find({categories: {$regex: 'Food'}}).stream();
        res.writeHead(200, { 'Content-Type': 'application/json'});
        console.log(req.ip);
        res.write('[');
        let first = true;
        resultStream.on('data', (data) => {
            if(first){
                first = false;
            }else {
                res.write(',');
            }
            res.write(JSON.stringify(data));
        });

        resultStream.on('end', () => {
            res.write(']');
            res.end();
            console.log("closed");
        });
    });
});
app.get('/wiki/food/:query', function(req, res){
    MongoClient.connect(urlForMongo, {useNewUrlParser: true } , (err, client) => {
        let resultStream = client.db(wikiName).collection(wikiCollection).find({title: {$regex: `${req.params.query}`, $options: 'i'}, categories: {$regex: 'Food'}}).stream();
        res.writeHead(200, { 'Content-Type': 'application/json'});
        console.log(req.ip);
        res.write('[')
        let first = true;
        resultStream.on('data', (data) => {
            if(first){
                first = false;
            }else {
                res.write(',');
            }
            res.write(JSON.stringify(data));
        });

        resultStream.on('end', () => {
            res.write(']');
            res.end();
            console.log("closed");
        });
    });
});

app.listen(8080, function(){
    console.log('Listening on port 8080');
});