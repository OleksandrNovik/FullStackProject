import TopicCode from "../components/UI/TopicCode/TopicCode";
import TopicHeader from "../components/UI/TopicHeader";
import TopicText from "../components/UI/TopicText";

// Map that returns component associated with its name
export const topicTypeMap = {
    header: TopicHeader,
    text: TopicText,
    code: TopicCode
}
// Type for a topic section elements (each of them can be only those types)
type TopicElementType = 'header' | 'text' | 'code';

interface TopicElementInfo {
    id: number;
    type: TopicElementType;
    innerText: string;
}

export default TopicElementInfo;