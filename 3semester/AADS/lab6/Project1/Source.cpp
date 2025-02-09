#include <iostream>
#include <string>
#include <map>
#include <vector>
#include <queue>
#include <algorithm>
#include <Windows.h>

using namespace std;

// ��������� ��� ���� ������ ��������
struct HuffmanNode {
    char ch;
    int freq;
    HuffmanNode* left;
    HuffmanNode* right;

    HuffmanNode(char c, int f) : ch(c), freq(f), left(nullptr), right(nullptr) {}
};

// ���������� ��� ������������ �������
struct Compare {
    bool operator()(HuffmanNode* l, HuffmanNode* r) {
        return l->freq > r->freq;
    }
};

// ������� ��� ���������� ������ ��������
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

// ������� ��� ������ ����� ��������
void printHuffmanCodes(HuffmanNode* root, const string& str, map<char, string>& huffmanCodes) {
    if (!root) return;

    if (root->ch != '\0') {
        huffmanCodes[root->ch] = str;
        cout << root->ch << ": " << str << endl;
    }

    printHuffmanCodes(root->left, str + "0", huffmanCodes);
    printHuffmanCodes(root->right, str + "1", huffmanCodes);
}

// ������� ��� �������� ���������� ������� ������� � ������
map<char, int> getCountOfSymbol(const string& str) {
    map<char, int> symbols;
    for (char c : str) {
        symbols[c]++;
    }
    return symbols;
}

// ������� ��� ������ ������� ������������� ��������
void printCount(const string& str) {
    map<char, int> freqMap = getCountOfSymbol(str);
    int totalChars = str.length();

    
    cout << "������\t����������\n";
    for (const auto& pair : freqMap) {
        cout << pair.first << "\t" << pair.second << "\n";
    }
}

// ������� ��� ������ �������� ������������������
void printOutputSequence(const string& str, const map<char, string>& huffmanCodes) {
    
    for (char c : str) {
        cout << huffmanCodes.at(c);
    }
    cout << endl;
}

// ������� ��� ���������� � ������ ������ �������� � �����
void buildAndPrintHuffmanTree(const string& str) {
    map<char, int> freqMap = getCountOfSymbol(str);
    HuffmanNode* root = buildHuffmanTree(freqMap);

    cout << "\n������� ������������� ��������:\n";
    printCount(str);

    cout << "\n���� ��������:\n";
    map<char, string> huffmanCodes;
    printHuffmanCodes(root, "", huffmanCodes);

    cout << "\n�������� ������������������:\n";
    printOutputSequence(str, huffmanCodes);
}

int main() {
    setlocale(LC_ALL, "rus");
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    string str;
    cout << "������� ������: ";
    getline(cin, str);

    buildAndPrintHuffmanTree(str);

    return 0;
}
