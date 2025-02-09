#include <iostream>
#include <string>
#include <map>
#include <vector>
#include <queue>
#include <algorithm>
#include <Windows.h>

using namespace std;

#define MAX INT_MIN

// Структура для узла дерева Хаффмана
struct HuffmanNode {
    char ch;
    int freq;
    HuffmanNode* left;
    HuffmanNode* right;

    HuffmanNode(char c, int f) : ch(c), freq(f), left(nullptr), right(nullptr) {}
};

// Компаратор для приоритетной очереди
struct Compare {
    bool operator()(HuffmanNode* l, HuffmanNode* r) {
        return l->freq > r->freq;
    }
};

// Функция для построения дерева Хаффмана
HuffmanNode* buildHuffmanTree(map<char, int>& freqMap) {
    priority_queue<HuffmanNode*, vector<HuffmanNode*>, Compare> minHeap;

    for (const auto& pair : freqMap) {
        minHeap.push(new HuffmanNode(pair.first, pair.second));
    }

    while (minHeap.size() > 1) {
        HuffmanNode* left = minHeap.top();
        minHeap.pop();
        HuffmanNode* right = minHeap.top();
        minHeap.pop();

        HuffmanNode* node = new HuffmanNode('\0', left->freq + right->freq);
        node->left = left;
        node->right = right;

        minHeap.push(node);
    }

    return minHeap.top();
}

// Функция для печати кодов Хаффмана
void printHuffmanCodes(HuffmanNode* root, const string& str) {
    if (!root) return;

    if (root->ch != '\0') {
        cout << root->ch << ": " << str << endl;
    }

    printHuffmanCodes(root->left, str + "0");
    printHuffmanCodes(root->right, str + "1");
}

// Функция для подсчета количества каждого символа в строке
map<char, int> getCountOfSymbol(const string& str) {
    map<char, int> symbols;
    for (char c : str) {
        symbols[c]++;
    }
    return symbols;
}

// Функция для сортировки символов по убыванию частоты
vector<pair<string, int>> sortByValue(map<char, int>& value) {
    vector<pair<string, int>> sorted;
    for (const auto& item : value) {
        sorted.push_back(make_pair(string(1, item.first), item.second));
    }
    sort(sorted.begin(), sorted.end(), [](pair<string, int> a, pair<string, int> b) {
        return a.second > b.second;
        });
    return sorted;
}

// Функция для сортировки вектора
vector<pair<string, int>> sortByValue(vector<pair<string, int>>& value) {
    sort(value.begin(), value.end(), [](pair<string, int> a, pair<string, int> b) {
        return a.second > b.second;
        });
    return value;
}

// Функция для объединения значений
vector<pair<string, int>> confluenceValue(vector<pair<string, int>>& value) {
    int sum = 0;
    string str = "";
    int n = 0;

    for (int i = value.size() - 1; i >= 0; i--) {
        sum += value[i].second;
        str += value[i].first;
        value.pop_back();
        n++;
        if (n == 2) {
            break;
        }
    }

    if (!str.empty()) {
        value.push_back(make_pair(str, sum));
    }

    return value;
}

void buildHuffmanTree(const string& str) {
    map<char, int> value = getCountOfSymbol(str);
    vector<pair<string, int>> sortedValue = sortByValue(value);

    cout << "Символ" << " " << "Количество" << endl;
    for (const auto& item : sortedValue) {
        cout << item.first << " \t " << item.second << endl;
    }

    while (sortedValue.size() > 1) {
        sortedValue = confluenceValue(sortedValue);
        sortedValue = sortByValue(sortedValue);

        for (const auto& item : sortedValue) {
            cout << item.first << " \t " << item.second << endl;
        }
    }

    HuffmanNode* root = buildHuffmanTree(value);
    cout << "\nКоды Хаффмана:\n";
    printHuffmanCodes(root, "");
}

int main() {
    setlocale(LC_ALL, "rus");
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    string str;
    cout << "Введите строку: ";
    getline(cin, str);

    buildHuffmanTree(str);


    return 0;
}