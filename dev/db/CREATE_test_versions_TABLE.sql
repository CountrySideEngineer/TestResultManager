CREATE TABLE "test_versions" (
	"id"	INTEGER,
	"version_code"	TEXT NOT NULL,
	"previous_version_code_id"	INTEGER DEFAULT 0,
	"products_id"	INTEGER NOT NULL DEFAULT 0,
	"created_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("id"),
	FOREIGN KEY("products_id") REFERENCES "products"("id") ON UPDATE CASCADE,
	FOREIGN KEY("previous_version_code_id") REFERENCES "test_versions"("id") ON UPDATE CASCADE ON DELETE SET NULL,
	UNIQUE("version_code","products_id")
)