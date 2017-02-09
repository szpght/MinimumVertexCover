# MinimumVertexCover

Student project - calculator of minimum vertex cover of graph.

Interface is in Polish.

## Usage

Format of input:
`[name of edge] [number of 1st vertex] [number of 2nd vertex] [weight]`

Weight is ignored. Lines not conforming to format are ignored.

Example input: 
```
a 1-2 1
b 2-3 2
c 1-4 1
```

Example output:
```
Bazy minimalne: (minimal vertex covers)
B1: 1, 2, 
B2: 1, 3, 
B3: 2, 4, 

Zbiory niezależne: (independent sets)
S1: 3, 4, 
S2: 2, 4, 
S3: 1, 3, 
```
