export interface ticket {
    id?: number;
    protocol?: string;
    priority?: string;
    priorityId?: number;
    complexity?: string;
    complexityId?: number;
    subject?: string;
    createdBy?: string;
    changedBy?: string;
    createdDate?: Date;
    changedDate?: Date;
}
