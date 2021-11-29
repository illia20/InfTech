"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const cors_1 = __importDefault(require("cors"));
const mongoose_1 = __importDefault(require("mongoose"));
const db_routes_1 = __importDefault(require("./routes/db.routes"));
const table_routes_1 = __importDefault(require("./routes/table.routes"));
const column_routes_1 = __importDefault(require("./routes/column.routes"));
const row_routes_1 = __importDefault(require("./routes/row.routes"));
const config_1 = __importDefault(require("./config"));
const PORT = process.env.PORT || 5000;
const app = (0, express_1.default)();
app.use(express_1.default.json());
app.use((0, cors_1.default)());
app.get("/", (req, res) => {
    res.status(200).send("Hello world");
});
app.use("/db", db_routes_1.default);
app.use("/table", table_routes_1.default);
app.use("/column", column_routes_1.default);
app.use("/row", row_routes_1.default);
function start() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            yield mongoose_1.default.connect(config_1.default, {
                useNewUrlParser: true,
                useUnifiedTopology: true,
            });
            app.listen(PORT, () => console.log(`Listening on port ${PORT}`));
        }
        catch (error) {
            console.log(`Error: ${error.message}`);
        }
    });
}
start();
