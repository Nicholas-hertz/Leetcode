/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* reverseList(struct ListNode* head) {
    struct ListNode* temp = head;
    struct ListNode* prev = NULL;
    while(temp){
        struct ListNode* next=temp->next;
        temp->next = prev;
        prev = temp;
        temp = next;
    }
    return prev;
}