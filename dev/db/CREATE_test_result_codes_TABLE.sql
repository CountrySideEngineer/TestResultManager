CREATE TABLE "test_result_codes" (
	"id"	INTEGER,
	"result_text"	TEXT NOT NULL,
	"output_text"	TEXT NOT NULL,
	"created_at"	TEXT DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT DEFAULT CURRENT_TIMESTAMP,
	UNIQUE("result_text","output_text"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
